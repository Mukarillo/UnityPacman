using System;
using UnityEditor;
using UnityEngine;

public class BoardCreatorWindow : EditorWindow
{
    private Vector2Int boardSize = new Vector2Int(35, 28);
    private TileViewInfo[][] tilesInfo;
    private TileViewInfo selectedTile;

    [MenuItem("Window/Pacman/Board Creator")]
    static void Init()
    {
        var window = (BoardCreatorWindow)EditorWindow.GetWindow(typeof(BoardCreatorWindow));
        window.minSize = new Vector2(600, 400);
        window.Show();
    }

    void OnGUI()
    {
        var rect = new Rect(0, 0, 200, 30);
        boardSize = EditorGUI.Vector2IntField(rect, "Board size", boardSize);
        CheckBoardChange();

        rect = new Rect(5, rect.height + 10, position.width - 10, 1);
        DrawUILine(Color.gray, rect);

        rect.y += rect.height + 10;
        rect.height = 50;
        EditorGUI.LabelField(rect, "BOARD TILES", EditorStyles.boldLabel);

        rect.width = position.width * 0.7f - 5;
        rect.y += rect.height - 30;
        rect.height = position.height - rect.height - rect.y + 45;

        DrawBoardTiles(rect);

        DrawUILine(Color.gray, new Rect(rect.width + 5, rect.y - 30, 1, rect.height + 50));

        if (selectedTile == null)
            return;

        rect.x = rect.width + 5;
        rect.width = position.width - rect.x - 5;
        DrawSelectedTile(rect);
    }

    private void CheckBoardChange()
    {
        if(tilesInfo == null)
        {
            tilesInfo = new TileViewInfo[boardSize.x][];
            for (int x = 0; x < boardSize.x; x++)
            {
                tilesInfo[x] = new TileViewInfo[boardSize.y];
                for (int y = 0; y < boardSize.y; y++)
                {
                    tilesInfo[x][y] = new TileViewInfo();
                }
            }
        }
        else
        {
            if(tilesInfo.Length != boardSize.x || tilesInfo[0].Length != boardSize.y)
            {
                var holder = tilesInfo;
                tilesInfo = new TileViewInfo[boardSize.x][];
                for (int x = 0; x < boardSize.x; x++)
                {
                    tilesInfo[x] = new TileViewInfo[boardSize.y];
                    for (int y = 0; y < boardSize.y; y++)
                    {
                        if (x < holder.Length && y < holder[x].Length)
                            tilesInfo[x][y] = holder[x][y];
                        else
                            tilesInfo[x][y] = new TileViewInfo();
                    }
                }
            }
        }
    }

    private void DrawBoardTiles(Rect rect)
    {
        GUI.Box(rect, Texture2D.whiteTexture);

        var buttonSpace = new Vector2(rect.width - 10, rect.height - 10);
        float buttonSize;
        if (buttonSpace.x < buttonSpace.y)
            buttonSize = buttonSpace.x / boardSize.x;
        else
            buttonSize = buttonSpace.y / boardSize.y;

        for (int x = 0; x < boardSize.x; x++)
        {
            for (int y = 0; y < boardSize.y; y++)
            {
                var xPos = 5 + rect.x + (buttonSize * x);
                var yPos = 5 + rect.y + (buttonSize * y);
                Texture texture = null;
                if(tilesInfo != null)
                {
                    texture = tilesInfo[x][y].sprite?.texture;
                }

                if (GUI.Button(new Rect(xPos, yPos, buttonSize, buttonSize), new GUIContent(texture)))
                {
                    SelectTileInfo(tilesInfo[x][y]);
                }
            }
        }
    }

    private void DrawSelectedTile(Rect rect)
    {
        var secondaryRect = new Rect(rect.x, rect.y, rect.width, 40);
        EditorGUI.LabelField(secondaryRect, $"SELECTED TILE", EditorStyles.boldLabel);

        secondaryRect.y += secondaryRect.height;
        secondaryRect.width = 200;
        secondaryRect.height = 200;
        selectedTile.sprite = (Sprite)EditorGUI.ObjectField(secondaryRect, selectedTile.sprite, typeof(Sprite), false);
    }

    private void SelectTileInfo(TileViewInfo tileViewInfo)
    {
        selectedTile = tileViewInfo;
    }

    private void DrawUILine(Color color, Rect rect)
    {
        EditorGUI.DrawRect(rect, color);
    }
}
