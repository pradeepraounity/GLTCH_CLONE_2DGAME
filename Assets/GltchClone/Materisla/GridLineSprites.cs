using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GridLineSprites : MonoBehaviour
{
	[SerializeField]
	private int rows, cols;
	public float tileSize = 1f;


	private LevelGrid levelGrid;

	public void Setup(LevelGrid levelGrid)
	{
		this.levelGrid = levelGrid;
	}

    private void Start()
    {
		rows = levelGrid.GetGridHeight();
		cols = levelGrid.GetGridWidth();

		Generate();
	}

    private void Generate()
	{
		GameObject referenceTiles = (GameObject)Instantiate(Resources.Load("BaseGridSprite"));

		for (int row = 0; row < rows; row++)
		{
			for (int col = 0; col < cols; col++)
			{
				GameObject tile = (GameObject)Instantiate(referenceTiles, transform);
				float posX = col * tileSize;
				float posY = row * tileSize;

				tile.transform.position = new Vector2(posX, posY);
			}
		}

		Destroy(referenceTiles);
	}
}