using PacEngine.board.prizes;
using PacEngine.utils;

namespace PacEngine.board.tiles
{
    public class BlockerBoardTile : AbstractBoardTile
    {
        public override bool IsWalkable => false;

        public BlockerBoardTile(Vector position) : base(position)
        {

        }
    }
}
