using PacEngine.board;
using PacEngine.utils;

namespace PacEngine.characters.ghosts
{
    public class Inky : AbstractGhostCharacter
    {
        private const int MID_POINT_MULTIPLIER = 2;
        public Inky(Vector initialPosition, Board board) : base(initialPosition, board)
        {
            ChangeState(GhostState.LOCKED);
        }

        protected override Vector ScatterPosition => new Vector(0, Board.Tiles[0].Length - 2);

        protected override Vector GetChaseTarget()
        {
            var midPoint = PacmanEngine.Instance.Pacman.Position + (PacmanEngine.Instance.Pacman.HeadingDirection * MID_POINT_MULTIPLIER);
            if (PacmanEngine.Instance.UseBuggedVersion && PacmanEngine.Instance.Pacman.HeadingDirection.Compare(Vector.UP))
                midPoint += Vector.LEFT * MID_POINT_MULTIPLIER;

            var target = Board.ToBounds(PacmanEngine.Instance.Blinky.Position + ((midPoint - PacmanEngine.Instance.Blinky.Position) * 2));

            return target;
        }

        internal override void Start(Vector position)
        {
            ChangeState(GhostState.LOCKED);

            base.Start(position);
        }
    }
}
