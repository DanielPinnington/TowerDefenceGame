using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavePoint : MonoBehaviour
{
    const int gridSize = 10;
    Vector2Int gridPos; //A pair of Ints together (look up later for disseratation)

    void Start()
    {
        
    }

    public int getGridSize()
    {
        return gridSize;
    }
    public Vector2 GetGridPos()
    {
        return new Vector2Int(//Takes position, divides by 10 and rounds the X position to nearest number. 
                             //Example: 6 / 10 = 0.6 (RoundToInt = 1)
                             //Finally: 1 * 10f = 10f.
         Mathf.RoundToInt(transform.position.x / gridSize) * gridSize,
         Mathf.RoundToInt(transform.position.z / gridSize) * gridSize);
    }
    void Update()
    {
        
    }
}
