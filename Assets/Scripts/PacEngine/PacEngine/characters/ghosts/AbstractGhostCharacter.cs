using System.Collections.Generic;
using PacEngine.board;
using PacEngine.utils;

namespace PacEngine.characters.ghosts
{
    public abstract class AbstractGhostCharacter : AbstractCharacter
    {
        public AbstractGhostCharacter(Vector initialPosition, Board board) : base(initialPosition, board)
        {
        }

        protected abstract Vector GetTarget();

        public void MoveToTarget()
        {
            var direction = PathFinder.GetNextMove(Position, GetTarget(), board, GetAvailableDirectionsAtCurrentTile());
            Move(direction);
        }

        protected List<Vector> GetAvailableDirectionsAtCurrentTile()
        {
            var p = CurrentTile.AvailableDirectionsToWalk;
            p.Remove(lastMoveDirection);
            return p;
        }
    }
}
