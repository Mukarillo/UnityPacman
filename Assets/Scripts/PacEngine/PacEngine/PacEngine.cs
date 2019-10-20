using System.Collections.Generic;
using PacEngine.board;
using PacEngine.board.tiles;
using PacEngine.characters;
using PacEngine.characters.ghosts;
using PacEngine.utils;

namespace PacEngine
{
    public class PacEngine
    {
        private static PacEngine instance;
        public static PacEngine Instance => instance ?? (instance = new PacEngine());

        public bool UseBuggedVersion => true;
        public Board Board { get; private set; }

        public Pacman Pacman { get; private set; }
        public Blinky Blinky { get; private set; }
        public Pinky Pinky { get; private set; }
        public Inky Inky { get; private set; }
        public Clyde Clyde { get; private set; }

        public List<AbstractGhostCharacter> Ghosts => new List<AbstractGhostCharacter>
        {
            Blinky,
            Pinky,
            Inky,
            Clyde
        };

        public PacEngine()
        {
        }

        public void InitiateGame(TileInfo[][] boardTiles, Vector pacmanPosition, Vector ghostSpawnPosition)
        {
            Board = new Board(boardTiles, ghostSpawnPosition);
            Pacman = new Pacman(pacmanPosition, Board);
            Blinky = new Blinky(ghostSpawnPosition + Vector.LEFT * 2, Board);
            Pinky = new Pinky(ghostSpawnPosition + Vector.LEFT, Board);
            Inky = new Inky(ghostSpawnPosition, Board);
            Clyde = new Clyde(ghostSpawnPosition + Vector.RIGHT, Board);
        }
    }
}
