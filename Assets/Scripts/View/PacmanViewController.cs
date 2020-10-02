using System.Collections.Generic;
using PacEngine;
using PacEngine.board.prizes;
using PacEngine.board.tiles;
using PacEngine.utils;
using UnityEngine;

public class PacmanViewController : MonoBehaviour
{
    private Dictionary<KeyCode, Vector> keyToDir = new Dictionary<KeyCode, Vector>
    {
        { KeyCode.W, Vector.UP },
        { KeyCode.A, Vector.LEFT },
        { KeyCode.S, Vector.DOWN },
        { KeyCode.D, Vector.RIGHT },
        { KeyCode.UpArrow, Vector.UP },
        { KeyCode.LeftArrow, Vector.LEFT },
        { KeyCode.DownArrow, Vector.DOWN },
        { KeyCode.RightArrow, Vector.RIGHT }
    };
        
    public BoardView boardView;

    // Start is called before the first frame update
    void Start()
    {
        var boardTiles = new TileInfo[][]
            {
                new TileInfo[] { GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0) },

                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0, 2), GetInfo(0, 1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1, new List<Vector> { Vector.UP }), GetInfo(0, forbiddenMovement: new List<Vector> { Vector.UP }), GetInfo(0, forbiddenMovement: new List<Vector> { Vector.UP }), GetInfo(0, 1, new List<Vector> { Vector.UP }), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 2), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1) },
/*center*/      new TileInfo[] { GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0, 1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0, 1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0) },
                new TileInfo[] { GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(2,1), GetInfo(2,1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0) },

                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0, forbiddenMovement: new List<Vector> { Vector.UP }), GetInfo(0, forbiddenMovement: new List<Vector> { Vector.UP }), GetInfo(0, forbiddenMovement: new List<Vector> { Vector.UP }), GetInfo(0, forbiddenMovement: new List<Vector> { Vector.UP }), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(0) },

                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0, 2), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 2), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(0, 1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0) },
            };

        var pacPos = new Vector(8, 14);
        var positionInFrontPrizion = new Vector(20, 14);
        var positionInsidePrizion = new Vector(17, 14);
        PacmanEngine.Instance.SetupBoard(boardTiles, pacPos, positionInFrontPrizion, positionInsidePrizion);

        boardView.Pacman.LinkEngineCharacter(PacmanEngine.Instance.Pacman);
        boardView.Blinky.LinkEngineCharacter(PacmanEngine.Instance.Blinky);
        boardView.Pinky.LinkEngineCharacter(PacmanEngine.Instance.Pinky);
        boardView.Inky.LinkEngineCharacter(PacmanEngine.Instance.Inky);
        boardView.Clyde.LinkEngineCharacter(PacmanEngine.Instance.Clyde);

        boardView.CreateDotsAndPellets(PacmanEngine.Instance.Board.Tiles);

        PacmanEngine.Instance.InitiateGame();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            PacmanEngine.Instance.Ghosts.ForEach(x => x.Scatter());

        if (Input.GetKeyDown(KeyCode.Alpha2))
            PacmanEngine.Instance.Ghosts.ForEach(x => x.Chase());

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            PacmanEngine.Instance.Pinky.Unlock();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            PacmanEngine.Instance.Inky.Unlock();
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            PacmanEngine.Instance.Clyde.Unlock();
        }

        foreach (var kvp in keyToDir)
        {
            if (Input.GetKey(kvp.Key))
            {
                PacmanEngine.Instance.Pacman.ChangeHeadingDirection(kvp.Value);
                break;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PacmanEngine.Instance.EnableSpeedMode();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            PacmanEngine.Instance.DisableSpeedMode();
        }
    }

    private static TileInfo GetInfo(int id, int prize = 0, List<Vector> forbiddenMovement = null, Vector? doorOutDirection = null)
    {
        return new TileInfo {
            TileType = (TileFactory.TileTypes)id,
            PrizeType = (PrizeFactory.PrizeTypes)prize,
            ForbiddenMovement = forbiddenMovement,
            doorOutDirection = doorOutDirection ?? Vector.UP
        };
    }
}
