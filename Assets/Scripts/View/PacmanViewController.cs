using System;
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
        { KeyCode.W, Vector.DOWN },
        { KeyCode.A, Vector.LEFT },
        { KeyCode.S, Vector.UP },
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
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0) },

                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0, forbiddenMovement: new List<Vector> { Vector.UP }), GetInfo(0, forbiddenMovement: new List<Vector> { Vector.UP }), GetInfo(0, forbiddenMovement: new List<Vector> { Vector.UP }), GetInfo(0, forbiddenMovement: new List<Vector> { Vector.UP }), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1) },
                new TileInfo[] { GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0) },
                new TileInfo[] { GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0) },

                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0, forbiddenMovement: new List<Vector> { Vector.UP }), GetInfo(0, forbiddenMovement: new List<Vector> { Vector.UP }), GetInfo(0, forbiddenMovement: new List<Vector> { Vector.UP }), GetInfo(0, forbiddenMovement: new List<Vector> { Vector.UP }), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(0) },

                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(1), GetInfo(0) },
                new TileInfo[] { GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0), GetInfo(0) },
            };

        var pacPos = new Vector(8, 14);
        var blinkPos = new Vector(20, 14);
        PacmanEngine.Instance.InitiateGame(boardTiles, pacPos, blinkPos);

        boardView.pacman.Move(pacPos);
        boardView.blinky.Move(blinkPos);
    }

    void Update()
    {
        foreach (var kvp in keyToDir)
        {
            if (Input.GetKeyDown(kvp.Key))
                MovePacmanAndGhosts(kvp.Value);
        }
    }

    private void MovePacmanAndGhosts(Vector vector)
    {
        PacmanEngine.Instance.Pacman.Move(vector);
        PacmanEngine.Instance.Ghosts.ForEach(x => x.DoDecision());

        boardView.pacman.Move(PacmanEngine.Instance.Pacman.Position);
        boardView.blinky.Move(PacmanEngine.Instance.Blinky.Position);

    }

    private static TileInfo GetInfo(int id, int prize = 0, List<Vector> forbiddenMovement = null)
    {
        return new TileInfo { TileType = (TileFactory.TileTypes)id, PrizeType = (PrizeFactory.PrizeTypes)prize, ForbiddenMovement = forbiddenMovement };
    }
}
