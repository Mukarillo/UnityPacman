using PacEngine.board.tiles;
using UnityEngine;

public class TileViewInfo
{
    public TileInfo engineInfo;
    public Sprite sprite;

    public TileViewInfo(TileInfo engineInfo, Sprite sprite)
    {
        this.engineInfo = engineInfo;
        this.sprite = sprite;
    }

    public TileViewInfo()
    {
        engineInfo = new TileInfo();
    }
}

public class TileView : MonoBehaviour
{

}
