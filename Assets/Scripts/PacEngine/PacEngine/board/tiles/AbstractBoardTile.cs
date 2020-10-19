using System.Collections.Generic;
using PacEngine.utils;

namespace PacEngine.board.tiles
{
    public abstract class AbstractBoardTile
    {
        public Vector Position { get; private set; }
        public Dictionary<Vector, AbstractBoardTile> DirectionNeighbor { get; private set; } = new Dictionary<Vector, AbstractBoardTile>();
        public List<Vector> AvailableDirectionsToWalk { get; private set; } = new List<Vector>();

        protected bool allowDoorMovement = true;

        protected AbstractBoardTile(Vector position)
        {
            Position = position;
        }

        public virtual void ResolveNeighbors(Board board)
        {
            var possibilities = Vector.ALL_DIRECTIONS;

            foreach (var direction in possibilities)
            {
                var neighborPosition = new Vector(Position.x, Position.y) + direction;

                if (board.TryGetTileAt(neighborPosition, out var element))
                    DirectionNeighbor.Add(direction, element);

                if (element is WalkableBoardTile || (element is DoorBoardTile && allowDoorMovement))
                    AvailableDirectionsToWalk.Add(direction);
            }
        }

        public Vector DistanceFrom(AbstractBoardTile tile)
        {
            return new Vector(tile.Position.x - Position.x, tile.Position.y - Position.y);
        }
    }
}
