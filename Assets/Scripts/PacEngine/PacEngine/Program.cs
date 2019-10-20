using System;
using System.Collections.Generic;
using PacEngine.board.prizes;
using PacEngine.board.tiles;
using PacEngine.utils;

namespace PacEngine
{
    class MainClass
    {
        private static Dictionary<string, Vector> keyToDir = new Dictionary<string, Vector>
        {
            { "w", Vector.UP },
            { "a", Vector.LEFT },
            { "s", Vector.DOWN },
            { "d", Vector.RIGHT }
        };

        public static void Main(string[] args)
        {
            var boardTiles = new TileInfo[][]
            {
                new TileInfo[] { GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0) },
            };

            PacEngine.Instance.InitiateGame(boardTiles, new Vector(24, 15), new Vector(12, 14));

            Console.Write(PacEngine.Instance.Board);

            while (true)
            {
                var k = Console.ReadLine();
                if(keyToDir.TryGetValue(k, out var vector))
                {
                    PacEngine.Instance.Pacman.Move(vector);
                    PacEngine.Instance.Ghosts.ForEach(x => x.DoDecision());
                    Console.Write(PacEngine.Instance.Board);
                }
            }
        }

        private static TileInfo GetInfo(int id, int prize = 0, List<Vector> forbiddenMovement = null)
        {
            return new TileInfo { TileType = (TileFactory.TileTypes)id, PrizeType = (PrizeFactory.PrizeTypes)prize, ForbiddenMovement = forbiddenMovement };
        }
    }
}
