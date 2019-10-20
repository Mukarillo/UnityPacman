using System.Collections.Generic;
using PacEngine.board.prizes;
using PacEngine.utils;
using System.Linq;

namespace PacEngine.board.tiles
{
    public class WalkableBoardTile : AbstractBoardTile
    {
        public override bool IsWalkable => true;

        public AbstractPrize Prize { get; private set; }
        public List<Vector> ForbiddenMovementDirections { get; private set; }

        public override List<Vector> AvailableDirectionsToWalk => base.AvailableDirectionsToWalk.Except(ForbiddenMovementDirections).ToList();

        public WalkableBoardTile(Vector position, AbstractPrize prize, List<Vector> forbiddenMovementDirections) : base(position)
        {
            Prize = prize;
            ForbiddenMovementDirections = forbiddenMovementDirections;
        }
    }
}
