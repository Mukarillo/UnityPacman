using PacEngine.board;
using PacEngine.utils;

namespace PacEngine.characters.ghosts
{
    public class Clyde : AbstractGhostCharacter
    {
        private const int MIN_DIST_TO_CHASE = 8;
        protected override Vector ScatterPosition => new Vector(Board.Tiles.Length, 0);

        public Clyde(Vector initialPosition, Board board) : base(initialPosition, board)
        {

        }

        protected override Vector GetChaseTarget()
        {
            var chase = (PacmanEngine.Instance.Pacman.Position - Position).Magnitude > MIN_DIST_TO_CHASE;
            return chase ? PacmanEngine.Instance.Pacman.Position : ScatterPosition;
        }
    }
}
