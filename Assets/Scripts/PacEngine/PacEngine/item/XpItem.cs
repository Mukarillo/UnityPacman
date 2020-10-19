using System.Collections.Generic;
using System.Linq;
using PacEngine.board;
using PacEngine.board.tiles;
using PacEngine.characters;
using PacEngine.utils;

namespace Assets.Scripts.PacEngine.PacEngine.item
{
    public class XpItem:AbstractCharacter
    {
        protected override float SpeedMultiplier => 0.2f;

        public XpItem(Vector initialPosition, Board board) : base(initialPosition, board)
        {
        }

        protected override void DoDecision()
        {
            var possibilities = GetAvailableDirectionsAtCurrentTile();
            Vector direction;
            direction = RandomGenerator.Instance.GetRandom(possibilities);
            Move(direction);
        }

        protected override List<Vector> GetAvailableDirectionsAtCurrentTile()
        {
            if (CurrentTile.AvailableDirectionsToWalk?.Count == 0)
                return new List<Vector>();

            var p = CurrentTile.AvailableDirectionsToWalk;
            if (CurrentTile is WalkableBoardTile walkable)
                p = p.Except(walkable.ForbiddenMovementDirections).ToList();


            p.Remove(-LastMoveDirection);

            var door = CurrentTile.DirectionNeighbor.Where(x => x.Value is DoorBoardTile)?.Select(x => x.Value)?.ToList();
            door.ForEach(x => p.Remove(-((DoorBoardTile)x).OutDirection));

            return p;
        }

        protected override void OnTileArrive(AbstractBoardTile tile)
        {
            //throw new System.NotImplementedException();
        }

        protected override bool IsDoorWalkable()
        {
            return true;
        }
    }
}
