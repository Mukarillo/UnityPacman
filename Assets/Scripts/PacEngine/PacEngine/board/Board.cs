using PacEngine.board.tiles;
using PacEngine.utils;

namespace PacEngine.board
{
    public class Board
    {
        public AbstractBoardTile[][] Tiles { get; private set; }
        public Vector PositionInFrontOfPrision { get; private set; }
        public Vector PositionInsideOfPrision { get; private set; }

        public Board(TileInfo[][] boardTilesInfo, Vector positionInFrontOfPrision, Vector positionInsideOfPrision)
        {
            PositionInFrontOfPrision = positionInFrontOfPrision;
            PositionInsideOfPrision = positionInsideOfPrision;

            Tiles = new AbstractBoardTile[boardTilesInfo.Length][];
            for (int x = 0; x < boardTilesInfo.Length; x++)
            {
                Tiles[x] = new AbstractBoardTile[boardTilesInfo[x].Length];
                for (int y = 0; y < boardTilesInfo[x].Length; y++)
                {
                    Tiles[x][y] = TileFactory.GetTile(boardTilesInfo[x][y], new Vector(x, y));
                }
            }

            for (int x = 0; x < boardTilesInfo.Length; x++)
            {
                for (int y = 0; y < boardTilesInfo[x].Length; y++)
                {
                    Tiles[x][y].ResolveNeighbors(this);
                }
            }
        }

        internal Vector ToBounds(Vector vector)
        {
            var x = MathUtils.Clamp(vector.x, 0, Tiles.Length - 1);
            var newVector = new Vector(x, MathUtils.Clamp(vector.y, 0, Tiles[x].Length - 1));

            return newVector;
        }

        public override string ToString() => LogBoard();

        public bool TryGetTileAt(Vector position, out AbstractBoardTile element)
        {
            element = null;
            if (!InBounds(position))
                return false;

            element = Tiles[position.x][position.y];
            return true;
        }

        public AbstractBoardTile GetTileAt(Vector position)
        {
            if (!InBounds(position))
                throw new PacException($"Please make sure that position {position} is in map bounds. If you are not sure, use TryGetTileAt method instead");

            return Tiles[position.x][position.y];
        }

        private bool InBounds(Vector position)
        {
            return position.x >= 0 && position.x < Tiles.Length &&
                    position.y >= 0 && position.y < Tiles[position.x].Length;
        }

        public string LogBoard(Vector pos = new Vector())
        {
            var str = "";

            for (int x = 0; x < Tiles.Length; x++)
            {
                for (int y = 0; y < Tiles[x].Length; y++)
                {
                    var cPos = new Vector(x, y);
                    //if (pos.Compare(cPos))
                    //    str += "H";
                    //else if (PacmanEngine.Instance.Pacman.Position.Compare(cPos))
                    //    str += "u";
                    //else if (x == SpawnRoomPosition.x && y == SpawnRoomPosition.y)
                    //    str += "s";
                    //else if (PacmanEngine.Instance.Blinky.Position.Compare(cPos))
                    //    str += "b";
                    //else if (PacmanEngine.Instance.Clyde.Position.Compare(cPos))
                    //    str += "c";
                    //else if (PacmanEngine.Instance.Inky.Position.Compare(cPos))
                    //    str += "i";
                    //else if (PacmanEngine.Instance.Pinky.Position.Compare(cPos))
                    //    str += "p";
                    //else
                        str += Tiles[x][y];
                }
                str += "\n";
            }

            return str;
        }
    }
}
