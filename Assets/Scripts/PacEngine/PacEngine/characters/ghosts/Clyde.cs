using PacEngine.board;
using PacEngine.utils;

namespace PacEngine.characters.ghosts
{
    public class Clyde : AbstractGhostCharacter
    {
        private const int MIN_DIST_TO_CHASE = 8;
        protected override Vector ScatterPosition => new Vector(0, 1);

        public Clyde(Vector initialPosition, Board board) : base(initialPosition, board)
        {
            ChangeState(GhostState.LOCKED);
        }

        protected override Vector GetChaseTarget()
        {
            var chase = (PacmanEngine.Instance.Pacman.Position - Position).Magnitude > MIN_DIST_TO_CHASE;
            return chase ? PacmanEngine.Instance.Pacman.Position : ScatterPosition;
        }

        internal override void Start(Vector position)
        {
            ChangeState(GhostState.LOCKED);

            base.Start(position);
        }
    }
}
