using System;
using PacEngine.board;
using PacEngine.utils;

namespace PacEngine.characters.ghosts
{
    public class Inky : AbstractGhostCharacter
    {
        private const int MID_POINT_MULTIPLIER = 2;
        public Inky(Vector initialPosition, Board board) : base(initialPosition, board)
        {

        }

        protected override Vector ScatterPosition => new Vector(Board.Tiles.Length, Board.Tiles[0].Length);

        protected override Vector GetChaseTarget()
        {
            var midPoint = PacEngine.Instance.Pacman.Position + (PacEngine.Instance.Pacman.HeadingDirection * MID_POINT_MULTIPLIER);
            if (PacEngine.Instance.UseBuggedVersion && PacEngine.Instance.Pacman.HeadingDirection.Compare(Vector.UP))
                midPoint += Vector.LEFT * MID_POINT_MULTIPLIER;

            var target = Board.ToBounds(midPoint + (PacEngine.Instance.Blinky.Position - midPoint));

            return target;
        }
    }
}
