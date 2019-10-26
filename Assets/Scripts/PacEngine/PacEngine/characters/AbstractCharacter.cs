using System;
using PacEngine.board;
using PacEngine.board.tiles;
using PacEngine.utils;

namespace PacEngine.characters
{
    public abstract class AbstractCharacter
    {
        //Events
        public Action<Vector> OnMove;
        public Action<Vector> OnTeleport;

        public Vector Position { get; protected set; }

        public AbstractBoardTile CurrentTile => Board.GetTileAt(Position);
        public Vector HeadingDirection => LastMoveDirection;

        protected Board Board { get; private set; }
        protected Vector LastMoveDirection { get; set; }

        public float TimeToTravelOneTile => BaseTimeToTravelOneTile / SpeedMultiplier;
        protected virtual float SpeedMultiplier { get; } = 1f;
        protected float BaseTimeToTravelOneTile => 1f / 11f;

        private bool canMove = true;

        protected AbstractCharacter(Vector initialPosition, Board board)
        {
            Position = initialPosition;
            this.Board = board;

            LastMoveDirection = Vector.DOWN;
        }

        protected virtual bool Move(Vector direction)
        {
            if (!canMove)
                return false;

            LastMoveDirection = direction;

            Position += direction;
            if(Board.TryGetTileAt(Position, out var tile))
            {
                if (tile is BlockerBoardTile)
                {
                    Position -= direction;
                    return false;
                }


                canMove = false;
                OnTileArrive(tile);
                OnMove?.Invoke(Position);
                return true;
            }

            //Character reached the edges of the board, wrap the position
            var x = Position.x < 0 ? Board.Tiles.Length - 1 : Position.x >= Board.Tiles.Length ? 0 : Position.x;
            var y = Position.y < 0 ? Board.Tiles[x].Length - 1 : Position.y >= Board.Tiles[x].Length ? 0 : Position.y;

            Teleport(new Vector(x, y));
            return false;
        }

        public void DoneViewMove()
        {
            canMove = true;
        }

        private void Teleport(Vector position)
        {
            Position = position;
            OnTeleport?.Invoke(position);
        }

        protected virtual void OnTileArrive(AbstractBoardTile tile)
        {

        }
    }
}
