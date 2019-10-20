using System.Collections.Generic;
using PacEngine.board.prizes;
using PacEngine.utils;

namespace PacEngine.board.tiles
{
    internal class TileInfo
    {
        public Vector Position { get; set; }
        public TileFactory.TileTypes TileType { get; set; }
        public PrizeFactory.PrizeTypes PrizeType { get; set; }
        public Vector DestinationOnStep { get; set; }
    }

    public class TileFactory
    {
        public enum TileTypes
        {
            WALKABLE,
            BLOCKER,
            SIDE_TELEPORT
        }

        internal static AbstractBoardTile GetTile(TileInfo info)
        {
            switch(info.TileType)
            {
                case TileTypes.WALKABLE:
                    return new WalkableBoardTile(info.Position, PrizeFactory.GetPrize(info.PrizeType), new List<Vector>());
                case TileTypes.BLOCKER:
                    return new BlockerBoardTile(info.Position);
                case TileTypes.SIDE_TELEPORT:
                    return new SideTeleportBoardTile(info.Position, info.DestinationOnStep);
            }

            throw new PacException($"Tile of type {info.TileType} is not implemented in TileFactory.GetTile");
        }
    }
}
