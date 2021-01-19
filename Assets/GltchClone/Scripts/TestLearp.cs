using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLearp : MonoBehaviour
{
    public Vector2 gridPosition;
    public Vector2 gridPositionOldPos;

    void Start()
    {
        gridPosition = new Vector2Int(6, 20);
        gridPositionOldPos = new Vector2Int(6, 10);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            gridPosition.y += 1;
        }
    
        transform.position = Vector2.Lerp(transform.position, gridPosition, 5f * Time.deltaTime);
    }
}
