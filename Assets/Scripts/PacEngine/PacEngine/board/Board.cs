using PacEngine.board.tiles;
using PacEngine.utils;

namespace PacEngine.board
{
    public class Board
    {
        public AbstractBoardTile[][] Tiles { get; private set; }

        public Board(int[][] boardTilesIds)
        {
            Tiles = new AbstractBoardTile[boardTilesIds.Length][];
            for (int x = 0; x < boardTilesIds.Length; x++)
            {
                Tiles[x] = new AbstractBoardTile[boardTilesIds[x].Length];
                for (int y = 0; y < boardTilesIds[x].Length; y++)
                {
                    var info = new TileInfo
                    {
                        Position = new Vector(x, y),
                        TileType = (TileFactory.TileTypes)boardTilesIds[x][y],
                        PrizeType = prizes.PrizeFactory.PrizeTypes.NONE
                    };
                    Tiles[x][y] = TileFactory.GetTile(info);
                }
            }

            for (int x = 0; x < boardTilesIds.Length; x++)
            {
                for (int y = 0; y < boardTilesIds[x].Length; y++)
                {
                    Tiles[x][y].ResolveNeighbors(this);
                }
            }

            System.Console.WriteLine(LogBoard());
        }

        public override string ToString() => LogBoard();

        public bool GetTileAt(Vector position, out AbstractBoardTile element)
        {
            element = null;
            if (!InBounds(position))
                return false;

            element = Tiles[position.x][position.y];
            return true;
        }

        private bool InBounds(Vector position)
        {
            return position.x >= 0 && position.x < Tiles.Length &&
                    position.y >= 0 && position.y < Tiles[position.x].Length;
        }

        private string LogBoard()
        {
            var str = "";

            for (int x = 0; x < Tiles.Length; x++)
            {
                for (int y = 0; y < Tiles[x].Length; y++)
                {
                    str += Tiles[x][y];
                }
                str += "\n";
            }

            return str;
        }
    }
}
