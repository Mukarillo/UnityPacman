using System.Collections.Generic;
using PacEngine.board;
using PacEngine.characters;
using PacEngine.characters.ghosts;
using PacEngine.utils;

namespace PacEngine
{
    public class PacEngine
    {
        private static PacEngine instance;
        public static PacEngine Instance => instance ?? (instance = new PacEngine());

        public Board Board { get; private set; }
        public Pacman Pacman { get; private set; }
        public List<AbstractGhostCharacter> Ghosts { get; private set; }

        public PacEngine()
        {
        }

        public void InitiateGame(int[][] boardTiles, Vector pacmanPosition)
        {
            Board = new Board(boardTiles);
            Pacman = new Pacman(pacmanPosition, Board);
        }
    }
}
