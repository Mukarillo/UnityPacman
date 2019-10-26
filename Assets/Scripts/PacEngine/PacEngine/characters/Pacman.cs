using PacEngine.board;
using PacEngine.board.tiles;
using PacEngine.utils;

namespace PacEngine.characters
{
    public class Pacman : AbstractCharacter
    {
        private Vector? nextDirection = null;

        public Pacman(Vector initialPosition, Board board) : base (initialPosition, board)
        {
            LastMoveDirection = Vector.LEFT;
        }


        public void Move()
        {
            Move(LastMoveDirection);
        }

        public void ChangeHeadingDirection(Vector direction)
        {
            if (Board.TryGetTileAt(Position + direction, out var tile) && tile is BlockerBoardTile)
                nextDirection = direction;
            else
                LastMoveDirection = direction;
        }

        protected override void OnTileArrive(AbstractBoardTile tile)
        {
            base.OnTileArrive(tile);

            if (!nextDirection.HasValue)
                return;

            if (!tile.AvailableDirectionsToWalk.Contains(nextDirection.Value))
                return;

            LastMoveDirection = nextDirection.Value;
            nextDirection = null;
        }
    }
}
