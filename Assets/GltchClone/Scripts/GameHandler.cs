using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameHandler : MonoBehaviour
{

    [SerializeField] private GltchPlayer gltchPlayer;

    private LevelGrid levelGrid;

    private void Start()
    {
        Debug.Log("GameHandler.Start");

        levelGrid = new LevelGrid(6, 11);

        gltchPlayer.Setup(levelGrid);
        levelGrid.Setup(gltchPlayer);
    }

}
