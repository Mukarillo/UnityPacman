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
            var midPoint = PacmanEngine.Instance.Pacman.Position + (PacmanEngine.Instance.Pacman.HeadingDirection * MID_POINT_MULTIPLIER);
            if (PacmanEngine.Instance.UseBuggedVersion && PacmanEngine.Instance.Pacman.HeadingDirection.Compare(Vector.UP))
                midPoint += Vector.LEFT * MID_POINT_MULTIPLIER;

            var target = Board.ToBounds(midPoint + (PacmanEngine.Instance.Blinky.Position - midPoint));

            return target;
        }
    }
}
