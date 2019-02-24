using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] Color exploredColor;
    public bool isExplored = false;
    public Waypoint exploredFrom;
    Vector2Int gridPos;
    public bool isPlaceable = true; //Is block placeable?
    const int gridSize = 10;

    [SerializeField] TowerPan towerPrefab;
    const string towerParentName = "Towers";

    public void Update()
    {
    }

    public int getGridSize()
    {
        return gridSize;
    }

    public Vector2Int getGridPos()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x / gridSize),
            Mathf.RoundToInt(transform.position.z / gridSize));
    }

    void OnMouseOver() //Where is the mouse on screen ?
    {
        if (Input.GetMouseButtonDown(0)) //Left click
        {
            if (isPlaceable)
            {
                Instantiate(towerPrefab, transform.position, Quaternion.identity);
                isPlaceable = false;
            }
            else
            {
                print("Can't place it here");
            }
        }
     //   print(gameObject.name); //Mouse over "gameObject" in this case, cubes/enemies + their name.
    }
    
}