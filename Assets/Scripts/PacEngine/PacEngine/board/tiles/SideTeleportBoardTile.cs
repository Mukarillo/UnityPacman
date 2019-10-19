using PacEngine.utils;

namespace PacEngine.board.tiles
{
    public class SideTeleportBoardTile : WalkableBoardTile
    {
        public Vector DestinationOnStep { get; private set; }

        public SideTeleportBoardTile(Vector position, Vector destinationOnStep) : base (position, null)
        {
            DestinationOnStep = destinationOnStep;
        }
    }
}
