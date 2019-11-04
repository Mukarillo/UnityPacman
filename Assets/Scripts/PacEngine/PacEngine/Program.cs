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
            //Refactor
        }

        private static TileInfo GetInfo(int id, int prize = 0, List<Vector> forbiddenMovement = null)
        {
            return new TileInfo { TileType = (TileFactory.TileTypes)id, PrizeType = (PrizeFactory.PrizeTypes)prize, ForbiddenMovement = forbiddenMovement };
        }
    }
}
