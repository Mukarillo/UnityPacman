using System;
using System.Collections.Generic;
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
        public Action<bool> OnToggleVisibility;

        public Vector Position { get; protected set; }
        public bool IsActive { get; private set; }

        public AbstractBoardTile CurrentTile => Board.GetTileAt(Position);
        public Vector HeadingDirection => LastMoveDirection;

        protected Board Board { get; private set; }
        protected Vector LastMoveDirection { get; set; }

        public float TimeToTravelOneTile => BaseTimeToTravelOneTile / SpeedMultiplier;

        protected virtual float SpeedMultiplier => PacmanEngine.Instance.TurboMode ? 2f : 1f;

        protected float BaseTimeToTravelOneTile => 1f / 11f;

        protected abstract void DoDecision();
        protected abstract void OnTileArrive(AbstractBoardTile tile);

        protected AbstractCharacter(Vector initialPosition, Board board)
        {
            Teleport(initialPosition);
            this.Board = board;

            LastMoveDirection = Vector.DOWN;
        }

        protected virtual bool Move(Vector direction)
        {
            if (!IsActive || PacmanEngine.Instance.GameOver)
                return false;

            LastMoveDirection = direction;

            Position += direction;
            if(Board.TryGetTileAt(Position, out var tile))
            {
                if (tile is BlockerBoardTile && !(tile is DoorBoardTile && IsDoorWalkable()))
                {
                    Position -= direction;
                    return false;
                }

                OnMove?.Invoke(Position);
                return true;
            }

            //Character reached the edges of the board, wrap the position
            var x = Position.x < 0 ? Board.Tiles.Length - 1 : Position.x >= Board.Tiles.Length ? 0 : Position.x;
            var y = Position.y < 0 ? Board.Tiles[x].Length - 1 : Position.y >= Board.Tiles[x].Length ? 0 : Position.y;

            Teleport(new Vector(x, y));
            return false;
        }

        protected abstract List<Vector> GetAvailableDirectionsAtCurrentTile();
       
        protected abstract bool IsDoorWalkable();

        public void DoneViewMove()
        {
            Board.TryGetTileAt(Position, out var tile);
            OnTileArrive(tile);

            PacmanEngine.Instance.CheckCollision();
            DoDecision();
        }

        internal virtual void Start(Vector position)
        {
            Teleport(position);
            ToggleActive(true);
            ToggleVisibility(true);

            DoDecision();
        }
        internal virtual void Stop() => ToggleActive(false);

        protected virtual void ToggleActive(bool active)
        {
            IsActive = active;
        }

        internal void ToggleVisibility(bool active)
        {
            OnToggleVisibility?.Invoke(active);
        }

        private void Teleport(Vector position)
        {
            Position = position;
            OnTeleport?.Invoke(position);
        }
    }
}
