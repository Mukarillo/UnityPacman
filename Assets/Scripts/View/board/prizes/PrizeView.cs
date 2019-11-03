using PacEngine.board.prizes;
using UnityEngine.Tilemaps;

public class PrizeView
{
    public AbstractPrize Prize { get; private set; }
    public TileBase View { get; private set; }

    private BoardView boardView;

    public PrizeView(AbstractPrize prize, TileBase view, BoardView boardView)
    {
        Prize = prize;
        View = view;
        this.boardView = boardView;

        prize.OnCollect += HidePrize;
    }

    private void HidePrize()
    {
        boardView.EraseTileOnBoard(Prize.Position);
    }
}
