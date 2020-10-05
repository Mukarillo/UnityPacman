using PacEngine.utils;

namespace PacEngine.board.tiles
{
    public class DoorBoardTile : BlockerBoardTile
    {
        public Vector OutDirection { get; private set; }
        public DoorBoardTile(Vector outDirection, Vector position) : base(position)
        {
            OutDirection = outDirection;
            allowDoorMovement = false;
        }
    }
}
