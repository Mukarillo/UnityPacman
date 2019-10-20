using PacEngine.board;
using PacEngine.board.tiles;
using PacEngine.utils;

namespace PacEngine.characters
{
    public abstract class AbstractCharacter
    {
        public Vector Position { get; private set; }
        public AbstractBoardTile CurrentTile => Board.GetTileAt(Position);
        public Vector HeadingDirection => LastMoveDirection;

        protected Board Board { get; private set; }
        protected Vector LastMoveDirection { get; set; }

        protected AbstractCharacter(Vector initialPosition, Board board)
        {
            Position = initialPosition;
            this.Board = board;

            LastMoveDirection = Vector.DOWN;
        }

        public virtual bool Move(Vector direction)
        {
            Position += direction;
            if(Board.TryGetTileAt(Position, out var tile))
            {
                if (tile is BlockerBoardTile)
                {
                    Position -= direction;
                    return false;
                }

                OnTileArrive(tile);
                LastMoveDirection = direction;
                return true;
            }

            //Character reached the edges of the board, wrap the position
            var x = Position.x < 0 ? Board.Tiles.Length - 1 : Position.x >= Board.Tiles.Length ? 0 : Position.x;
            var y = Position.y < 0 ? Board.Tiles[x].Length - 1 : Position.y >= Board.Tiles[x].Length ? 0 : Position.y;

            Teleport(new Vector(x, y));
            return false;
        }

        private void Teleport(Vector position)
        {
            Position = position;
        }

        protected virtual void OnTileArrive(AbstractBoardTile tile)
        {

        }
    }
}
