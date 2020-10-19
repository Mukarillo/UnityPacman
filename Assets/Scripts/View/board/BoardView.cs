using System;
using System.Collections.Generic;
using Assets.Scripts.PacEngine.PacEngine.item;
using Assets.Scripts.View.characters.items;
using PacEngine;
using PacEngine.board.prizes;
using PacEngine.board.tiles;
using PacEngine.utils;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BoardView : MonoBehaviour
{
    [SerializeField] private Vector2Int prizesOffset;

    [SerializeField] private Tilemap tilemap;
    [SerializeField] private TileBase pacDot;
    [SerializeField] private TileBase powerPellet;

    [SerializeField] private PacmanView pacman;
    public PacmanView Pacman => pacman;

    [SerializeField] private BlinkyView blinky;
    public BlinkyView Blinky => blinky;

    [SerializeField] private PinkyView pinky;
    public PinkyView Pinky => pinky;

    [SerializeField] private InkyView inky;
    public InkyView Inky => inky;

    [SerializeField] private ClydeView clyde;
    public ClydeView Clyde => clyde;

    [SerializeField] private XpItemView xpItem;

    public XpItemView XpItem => xpItem;


    private List<PrizeView> prizes = new List<PrizeView>();


    public void CreateDotsAndPellets(AbstractBoardTile[][] board)
    {
        foreach (var t in board)
        {
            foreach (var t1 in t)
            {
                var consumable = GetViewPrizeInTile(t1);
                if (consumable == null) continue;
                prizes.Add(new PrizeView(consumable.Item2, consumable.Item1, this));

                PaintTileOnBoard(t1.Position, consumable.Item1);
            }
        }
    }

    public void PaintTileOnBoard(Vector position, TileBase tileBase)
    {
        tilemap.SetTile(new Vector3Int(position.y + prizesOffset.x, position.x + prizesOffset.y, 0), tileBase);
    }

    public void EraseTileOnBoard(Vector position)
    {
        PaintTileOnBoard(position, null);
    }

    private Tuple<TileBase, AbstractPrize> GetViewPrizeInTile(AbstractBoardTile tile)
    {
        var walkable = tile as WalkableBoardTile;
        if (walkable?.Prize == null) return null;

        switch(walkable.Prize.Type)
        {
            case PrizeFactory.PrizeTypes.NONE: return null;
            case PrizeFactory.PrizeTypes.PAC_DOTS: return new Tuple<TileBase, AbstractPrize>(pacDot, walkable.Prize);
            case PrizeFactory.PrizeTypes.POWER_PELLETS: return new Tuple<TileBase, AbstractPrize>(powerPellet, walkable.Prize); 
        }

        throw new PacException($"Id {walkable.Prize.Type} not implmented in BoardView.GetConsumableById");
    }
}
