using PacEngine.board;
using PacEngine.board.tiles;
using PacEngine.utils;

namespace PacEngine.characters
{
    public abstract class AbstractCharacter
    {
        public Vector Position { get; private set; }
        public AbstractBoardTile CurrentTile => board.GetTileAt(Position);

        protected Board board { get; private set; }
        protected Vector lastMoveDirection { get; private set; }

        public AbstractCharacter(Vector initialPosition, Board board)
        {
            Position = initialPosition;
            this.board = board;
        }

        public virtual bool Move(Vector direction)
        {
            Position += direction;
            if(board.TryGetTileAt(Position, out var tile))
            {
                OnTileArrive(tile);
                lastMoveDirection = direction;
                return true;
            }

            Position -= direction;
            return false;
        }

        protected virtual void OnTileArrive(AbstractBoardTile tile)
        {

        }
    }
}
