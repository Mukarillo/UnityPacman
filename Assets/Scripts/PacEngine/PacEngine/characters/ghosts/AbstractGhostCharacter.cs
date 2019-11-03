using System.Collections.Generic;
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
            FRIGHTENED
        }

        //Events
        public Action<GhostState> OnChangeState;

        public GhostState State { get; private set; } = GhostState.CHASE;
        public float TimeInFrightenedState { get; private set; } = 6f;
        public float TimeInScatterState { get; private set; } = 6f;

        protected abstract Vector ScatterPosition { get; }
        protected override float SpeedMultiplier => GetSpeedMultiplier();

        private CancellationTokenSource delayedCancellationCall;

        protected AbstractGhostCharacter(Vector initialPosition, Board board) : base(initialPosition, board)
        {
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
                    return Board.SpawnRoomPosition;
            }

            throw new PacException($"State {State} not implemented in GetTarget()");
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

        public void DoDecision()
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
            var p = CurrentTile.AvailableDirectionsToWalk.Except(((WalkableBoardTile)CurrentTile).ForbiddenMovementDirections).ToList();
            p.Remove(-LastMoveDirection);

            //If there are no options, the ghost is in the edge of the screen, so we force to walk towards the
            //void, so he can teleport to the other side of the board.
            if (p.Count == 0)
                p.Add(LastMoveDirection);

            return p;
        }

        protected override void OnTileArrive(AbstractBoardTile tile)
        {
            base.OnTileArrive(tile);

            if (State == GhostState.EATEN && tile.Position.Compare(Board.SpawnRoomPosition))
                Revive();
        }

        protected void Revive()
        {
            ChangeState(GhostState.CHASE);
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

            return 0.7f;
        }
    }
}
