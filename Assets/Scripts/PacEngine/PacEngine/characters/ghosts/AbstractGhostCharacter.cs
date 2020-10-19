using PacEngine.board;
using PacEngine.board.tiles;
using PacEngine.utils;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace PacEngine.characters.ghosts
{
    public abstract class AbstractGhostCharacter : AbstractCharacter
    {
        public enum GhostState
        {
            CHASE,
            SCATTER,
            EATEN,
            FRIGHTENED,
            LOCKED,
            UNLOCKED
        }

        //Events
        public Action<GhostState> OnChangeState;

        public virtual GhostState State { get; private set; } = GhostState.SCATTER;
        public float TimeInFrightenedState { get; private set; } = 6f;
        public float TimeInScatterState { get; private set; } = 6f;

        protected abstract Vector ScatterPosition { get; }
        protected override float SpeedMultiplier => GetSpeedMultiplier();

        private CancellationTokenSource delayedCancellationCall;

        protected AbstractGhostCharacter(Vector initialPosition, Board board) : base(initialPosition, board)
        {
            lockedTarget = initialPosition + (Vector.DOWN * 3);
        }

        public virtual Vector GetTarget()
        {
            switch(State)
            {
                case GhostState.CHASE:
                    return GetChaseTarget();
                case GhostState.SCATTER:
                    return ScatterPosition;
                case GhostState.EATEN:
                    return Board.PositionInsideOfPrision;
                case GhostState.LOCKED:
                    return LockedTarget();
                case GhostState.UNLOCKED:
                    return Board.PositionInFrontOfPrision;
            }

            throw new PacException($"State {State} not implemented in GetTarget()");
        }

        protected Vector lockedTarget;
        private Vector LockedTarget()
        {
            if (Board.TryGetTileAt(Position + (Vector.DOWN), out var t) && t is BlockerBoardTile)
                lockedTarget = Position + (Vector.UP * 3);
            if (Board.TryGetTileAt(Position + (Vector.UP), out t) && t is BlockerBoardTile)
                lockedTarget = Position + (Vector.DOWN * 3);


            return lockedTarget;
        }

        protected abstract Vector GetChaseTarget();

        public void Frightened()
        {
            delayedCancellationCall?.Cancel();

            TurnAround();
            ChangeState(GhostState.FRIGHTENED);
            WaitAndCall((int)(TimeInFrightenedState * 1000), Chase);
        }

        public void Chase()
        {
            TurnAround();
            ChangeState(GhostState.CHASE);
        }

        public void Scatter()
        {
            ChangeState(GhostState.SCATTER);
            WaitAndCall((int)(TimeInScatterState * 1000), Chase);
        }

        public void Eaten()
        {
            delayedCancellationCall?.Cancel();
            ChangeState(GhostState.EATEN);
        }

        public void Unlock()
        {
            ChangeState(GhostState.UNLOCKED);
        }

        protected override void DoDecision()
        {
            var possibilities = GetAvailableDirectionsAtCurrentTile();
            Vector direction;

            if (State == GhostState.FRIGHTENED)
                direction = RandomGenerator.Instance.GetRandom(possibilities);
            else
                direction = PathFinder.GetNextMove(Position, GetTarget(), GetAvailableDirectionsAtCurrentTile());

            Move(direction);
        }

        protected List<Vector> GetAvailableDirectionsAtCurrentTile()
        {
            if (CurrentTile.AvailableDirectionsToWalk?.Count == 0)
                return new List<Vector>();

            var p = CurrentTile.AvailableDirectionsToWalk;
            if (CurrentTile is WalkableBoardTile walkable)
                p = p.Except(walkable.ForbiddenMovementDirections).ToList();
            if(CurrentTile is DoorBoardTile)
                p.Remove(-LastMoveDirection);

            if (State != GhostState.LOCKED && State != GhostState.UNLOCKED)
            {
                p.Remove(-LastMoveDirection);

                var door = CurrentTile.DirectionNeighbor.Where(x => x.Value is DoorBoardTile)?.Select(x => x.Value)?.ToList();
                if (door != null && State != GhostState.EATEN)
                {
                    door.ForEach(x => p.Remove(-((DoorBoardTile) x).OutDirection));
                }
            }

            //If there are no options, the ghost is in the edge of the screen, so we force to walk towards the
            //void, so he can teleport to the other side of the board.
            if (p.Count == 0)
                p.Add(LastMoveDirection);

            return p;
        }

        protected override void OnTileArrive(AbstractBoardTile tile)
        {
            if (PacmanEngine.Instance.GameOver)
                return;

            if (State == GhostState.EATEN && tile.Position.Compare(Board.PositionInsideOfPrision))
                Revive();
            else if (State == GhostState.UNLOCKED && tile.Position.Compare(Board.PositionInFrontOfPrision))
            {
                UnityEngine.Debug.LogWarning("ARRIVING IN FRONT OF THE PRISION IN STATE UNLOCKED");
                ChangeState(GhostState.CHASE);
            }
        }

        protected override bool IsDoorWalkable()
        {
            return State == GhostState.UNLOCKED || State == GhostState.EATEN;
        }

        protected override void ToggleActive(bool active)
        {
            base.ToggleActive(active);
            ToggleVisibility(active);
        }

        protected void Revive()
        {
            //TODO: Change Sprite
            ChangeState(GhostState.UNLOCKED);
        }

        protected void ChangeState(GhostState state)
        {
            State = state;
            OnChangeState?.Invoke(State);
        }

        protected void TurnAround()
        {
            LastMoveDirection = -LastMoveDirection;
        }

        private async Task WaitAndCall(int time, Action callback)
        {
            delayedCancellationCall = new CancellationTokenSource();
            await Task.Delay(time, delayedCancellationCall.Token);
            callback.Invoke();
        }

        private float GetSpeedMultiplier()
        {
            if (State == GhostState.FRIGHTENED)
                return 0.5f;
            if (State == GhostState.EATEN)
                return 2f;

            return 0.5f;
        }
    }
}