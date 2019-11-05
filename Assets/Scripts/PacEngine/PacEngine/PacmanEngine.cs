using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PacEngine.board;
using PacEngine.board.tiles;
using PacEngine.characters;
using PacEngine.characters.ghosts;
using PacEngine.utils;

namespace PacEngine
{
    public class PacmanEngine
    {
        private float TIME_TO_RESET = 3f;

        private static PacmanEngine instance;
        public static PacmanEngine Instance => instance ?? (instance = new PacmanEngine());

        public bool UseBuggedVersion => true;
        public Board Board { get; private set; }

        public Pacman Pacman { get; private set; }
        public Blinky Blinky { get; private set; }
        public Pinky Pinky { get; private set; }
        public Inky Inky { get; private set; }
        public Clyde Clyde { get; private set; }

        public bool GameOver { get; private set; }

        public List<AbstractGhostCharacter> Ghosts => new List<AbstractGhostCharacter>
        {
            Blinky,
            Pinky,
            Inky,
            Clyde
        };

        private Vector pacmanPosition;
        private Vector positionInFrontOfPrision;
        private Vector positionInsideOfPrision;

        public void SetupBoard(TileInfo[][] boardTiles, Vector pacmanPosition, Vector positionInFrontOfPrision, Vector positionInsideOfPrision)
        {
            this.pacmanPosition = pacmanPosition;
            this.positionInFrontOfPrision = positionInFrontOfPrision;
            this.positionInsideOfPrision = positionInsideOfPrision;

            Board = new Board(boardTiles, positionInFrontOfPrision, positionInsideOfPrision);
            Pacman = new Pacman(pacmanPosition, Board);
            //Blinky = new Blinky(positionInFrontOfPrision, Board);
            Pinky = new Pinky(positionInsideOfPrision, Board);
            //Inky = new Inky((positionInsideOfPrision + (Vector.LEFT * 2)), Board);
            //Clyde = new Clyde((positionInsideOfPrision + (Vector.RIGHT * 2)), Board);
        }

        public void InitiateGame()
        {
            GameOver = false;
            Pacman.Start(pacmanPosition);

            //Blinky.Start(positionInFrontOfPrision);
            Pinky.Start(positionInsideOfPrision);
            //Inky.Start(positionInsideOfPrision + Vector.LEFT * 2);
            //Clyde.Start(positionInsideOfPrision + Vector.RIGHT * 2);
        }

        internal void CheckCollision()
        {
            //Ghosts.ForEach(CheckGhostCollision);
        }

        private void CheckGhostCollision(AbstractGhostCharacter ghost)
        {
            if (ghost.State == AbstractGhostCharacter.GhostState.EATEN)
                return;

            if (Pacman.Position.Equals(ghost.Position))
                ResolveCollision(ghost);
        }

        private void ResolveCollision(AbstractGhostCharacter ghost)
        {
            if (ghost.State == AbstractGhostCharacter.GhostState.FRIGHTENED)
                ghost.Eaten();
            else
                EndGame();
        }

        private void EndGame()
        {
            if (GameOver)
                return;

            GameOver = true;
            UnityEngine.Debug.LogWarning("GAME OVER");

            Pacman.Stop();
            Ghosts.ForEach(x => x.Stop());

            Pacman.Die();

            WaitAndCall(((int)TIME_TO_RESET * 1000), InitiateGame);
        }

        private async Task WaitAndCall(int time, Action callback)
        {
            await Task.Delay(time);
            callback.Invoke();
        }
    }
}
