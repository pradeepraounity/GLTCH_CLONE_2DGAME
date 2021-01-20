using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameHandler : MonoBehaviour
{

    public Camera _mainCam;

    [SerializeField] 
    private GltchPlayer gltchPlayer;

    [SerializeField]
    private GridLineSprites gridLineSprites;
    private LevelGrid levelGrid;

    [SerializeField]
    private int _gridWidth, _gridHeight = 0;

    public bool _isDynamicGrid;

    private void Awake()
    {
        Debug.Log("GameHandler.Start");
        Debug.Log(ScreenHeight());

        Init();
    }

    void Init()
    {
        if (_isDynamicGrid)
        {
            _gridWidth = ScreenWidth();
            _gridHeight = ScreenHeight();

            if (_gridWidth == 7)
                _mainCam.transform.position = new Vector3(3f, 5.98f, -10.0f);
            else
                _mainCam.transform.position = new Vector3(2.5f, 5.98f, -10.0f);

        }

        levelGrid = new LevelGrid(_gridWidth, _gridHeight);

        gltchPlayer.Setup(levelGrid);
        levelGrid.Setup(gltchPlayer);
        gridLineSprites.Setup(levelGrid);
    }

    int ScreenHeight()
    {
        int aproxHeight = 13;
        return aproxHeight;
    }

    int ScreenWidth()
    {
        int aproxWidth = 0;
        double value = (double)Screen.width / Screen.height;

        Debug.Log(value);

        if (value > 0.5)
            aproxWidth = 7;
        else
            aproxWidth = 6;

        return aproxWidth;
    }
}
