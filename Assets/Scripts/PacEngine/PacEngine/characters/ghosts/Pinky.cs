using System;
using PacEngine.board;
using PacEngine.utils;

namespace PacEngine.characters.ghosts
{
    public class Pinky : AbstractGhostCharacter
    {
        private const int PACMAN_HEADING_MULTIPLER = 4;
        protected override Vector ScatterPosition => new Vector(0, 2);

        public Pinky(Vector initialPosition, Board board) : base(initialPosition, board)
        {

        }

        protected override Vector GetChaseTarget()
        {
            var toAdd = (PacmanEngine.Instance.Pacman.HeadingDirection * PACMAN_HEADING_MULTIPLER);
            if (PacmanEngine.Instance.UseBuggedVersion && PacmanEngine.Instance.Pacman.HeadingDirection.Compare(Vector.UP))
                toAdd += Vector.LEFT * PACMAN_HEADING_MULTIPLER;
            return Board.ToBounds(PacmanEngine.Instance.Pacman.Position + toAdd);
        }
    }
}
