using PacEngine.board;
using PacEngine.utils;

namespace PacEngine.characters.ghosts
{
    public class Blinky : AbstractGhostCharacter
    {
        public Blinky(Vector initialPosition, Board board) : base(initialPosition, board)
        {

        }

        protected override Vector ScatterPosition => new Vector(Board.Tiles.Length, Board.Tiles[0].Length - 4);

        protected override Vector GetChaseTarget() => PacmanEngine.Instance.Pacman.Position;
    }
}
