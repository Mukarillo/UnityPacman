using PacEngine.board;
using PacEngine.utils;

namespace PacEngine.characters.ghosts
{
    public class Blinky : AbstractGhostCharacter
    {
        public Blinky(Vector initialPosition, Board board) : base(initialPosition, board)
        {

        }

        protected override Vector ScatterPosition => new Vector(0, Board.Tiles[0].Length - 3);

        protected override Vector GetChaseTarget() => PacmanEngine.Instance.Pacman.Position;
    }
}
