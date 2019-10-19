using System.Collections.Generic;
using PacEngine.utils;

namespace PacEngine.board.tiles
{
    public abstract class AbstractBoardTile
    {
        public abstract bool IsWalkable { get; }

        public Vector Position { get; private set; }
        public Dictionary<Vector, AbstractBoardTile> DirectionNeighbor { get; private set; } = new Dictionary<Vector, AbstractBoardTile>();

        public AbstractBoardTile(Vector position)
        {
            Position = position;
        }

        public override string ToString()
        {
            return $"{(IsWalkable ? "." : "x")}";
        }

        public void ResolveNeighbors(Board board)
        {
            var possibilities = new List<Vector>{ Vector.UP, Vector.LEFT, Vector.DOWN, Vector.RIGHT};

            foreach (var direction in possibilities)
            {
                var neighborPosition = new Vector(Position.x, Position.y) + direction;

                if (board.GetTileAt(neighborPosition, out var element))
                    DirectionNeighbor.Add(direction, element);
            }
        }

        public Vector DistanceFrom(AbstractBoardTile tile)
        {
            return new Vector(tile.Position.x - Position.x, tile.Position.y - Position.y);
        }
    }
}
