using System;
using PacEngine.board;
using PacEngine.board.tiles;
using PacEngine.utils;

namespace PacEngine.characters
{
    public class Pacman : AbstractCharacter
    {
        public Action OnDie;

        private Vector? nextDirection = null;
        private bool waitToMove;

        public Pacman(Vector initialPosition, Board board) : base(initialPosition, board)
        {
            LastMoveDirection = Vector.LEFT;
        }

        protected override void DoDecision()
        {
            waitToMove = Move(LastMoveDirection);
        }

        public void ChangeHeadingDirection(Vector direction)
        {
            var sameDirection = LastMoveDirection.Equals(direction);

            if (Board.TryGetTileAt(Position + direction, out var tile) && tile is BlockerBoardTile)
                nextDirection = direction;
            else
            {
                LastMoveDirection = direction;
                nextDirection = null;

                if (!sameDirection && !waitToMove)
                    DoDecision();
            }
        }

        protected override void OnTileArrive(AbstractBoardTile tile)
        {
            if (PacmanEngine.Instance.GameOver)
                return;

            waitToMove = false;

            (tile as WalkableBoardTile)?.Prize?.TryCollect();

            if (!nextDirection.HasValue)
                return;

            if (!tile.AvailableDirectionsToWalk.Contains(nextDirection.Value))
                return;

            LastMoveDirection = nextDirection.Value;
            nextDirection = null;
        }

        internal void Die()
        {
            OnDie?.Invoke();
        }
    }
}
