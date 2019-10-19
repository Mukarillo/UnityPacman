using PacEngine.board.prizes;
using PacEngine.utils;

namespace PacEngine.board.tiles
{
    public class WalkableBoardTile : AbstractBoardTile
    {
        public override bool IsWalkable => true;

        public AbstractPrize Prize { get; private set; }

        public WalkableBoardTile(Vector position, AbstractPrize prize) : base(position)
        {
            Prize = prize;
        }
    }
}
