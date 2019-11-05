using System.Collections.Generic;
using PacEngine.board.prizes;
using PacEngine.utils;

namespace PacEngine.board.tiles
{
    public class WalkableBoardTile : AbstractBoardTile
    {
        public AbstractPrize Prize { get; private set; }
        public List<Vector> ForbiddenMovementDirections { get; private set; }

        public WalkableBoardTile(Vector position, AbstractPrize prize, List<Vector> forbiddenMovementDirections) : base(position)
        {
            Prize = prize;
            ForbiddenMovementDirections = forbiddenMovementDirections ?? new List<Vector>();
        }
    }
}
