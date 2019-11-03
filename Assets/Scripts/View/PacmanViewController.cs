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
        { KeyCode.D, Vector.RIGHT }
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
                new TileInfo[] { GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1) },

/*center*/      new TileInfo[] { GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0, 1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0, 1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0) },

                new TileInfo[] { GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0, 1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0) },

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

        var pacPos = new Vector(8, 15);
        var blinkPos = new Vector(20, 14);
        PacmanEngine.Instance.InitiateGame(boardTiles, pacPos, blinkPos);

        boardView.Pacman.LinkEngineCharacter(PacmanEngine.Instance.Pacman);
        boardView.Blinky.LinkEngineCharacter(PacmanEngine.Instance.Blinky);
        boardView.Pinky.LinkEngineCharacter(PacmanEngine.Instance.Pinky);
        boardView.Inky.LinkEngineCharacter(PacmanEngine.Instance.Inky);
        boardView.Clyde.LinkEngineCharacter(PacmanEngine.Instance.Clyde);

        boardView.CreateDotsAndPellets(PacmanEngine.Instance.Board.Tiles);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            PacmanEngine.Instance.Ghosts.ForEach(x => x.Scatter());

        if (Input.GetKeyDown(KeyCode.Alpha2))
            PacmanEngine.Instance.Ghosts.ForEach(x => x.Chase());

        foreach (var kvp in keyToDir)
        {
            if (Input.GetKey(kvp.Key))
            {
                PacmanEngine.Instance.Pacman.ChangeHeadingDirection(kvp.Value);
                break;
            }
        }

        PacmanEngine.Instance.Step();
    }

    private static TileInfo GetInfo(int id, int prize = 0, List<Vector> forbiddenMovement = null)
    {
        return new TileInfo { TileType = (TileFactory.TileTypes)id, PrizeType = (PrizeFactory.PrizeTypes)prize, ForbiddenMovement = forbiddenMovement };
    }
}
