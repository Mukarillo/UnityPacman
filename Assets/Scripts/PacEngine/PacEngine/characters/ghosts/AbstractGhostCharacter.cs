using System.Collections.Generic;
using PacEngine.board;
using PacEngine.board.tiles;
using PacEngine.utils;
using System.Linq;

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

        public GhostState State { get; private set; } = GhostState.SCATTER;

        protected abstract Vector ScatterPosition { get; }

        protected AbstractGhostCharacter(Vector initialPosition, Board board) : base(initialPosition, board)
        {
        }

        protected virtual Vector GetTarget()
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
            return new Vector();
        }

        protected abstract Vector GetChaseTarget();

        public void Frightened()
        {
            LastMoveDirection = -LastMoveDirection;
            ChangeState(GhostState.FRIGHTENED);
        }

        public void Chase()
        {
            LastMoveDirection = -LastMoveDirection;
            ChangeState(GhostState.CHASE);
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
        }
    }
}
