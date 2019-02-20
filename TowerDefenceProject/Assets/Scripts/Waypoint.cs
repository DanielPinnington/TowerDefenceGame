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

    public void Update()
    {
        UpdateColor();
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

    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRender = transform.GetComponent<MeshRenderer>();
        topMeshRender.material.color = color;

    }
    private void UpdateColor()
    {
        Pathfinder pathfinder = GetComponentInParent<Pathfinder>();

        if (isExplored && this != pathfinder.startWayPoint && this != pathfinder.endWayPoint)
        {
            SetTopColor(Color.yellow);
        }
        else if (this == pathfinder.startWayPoint)
        {
            SetTopColor(Color.green);
        }
        else if (this == pathfinder.endWayPoint)
        {
            SetTopColor(Color.blue);
        }
    }

    void OnMouseOver() //Where is the mouse on screen ?
    {
        if (Input.GetMouseButtonDown(0)) //Left click
        {
            if (isPlaceable)
            {
                print("Tower Placement: " + gameObject.name);
            }
            else
            {
                print("Can't place it here");
            }
        }
     //   print(gameObject.name); //Mouse over "gameObject" in this case, cubes/enemies + their name.
    }
    
}