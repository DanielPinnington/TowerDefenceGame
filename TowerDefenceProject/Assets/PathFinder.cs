using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Waypoint startWayPoint, endWayPoint; //Allows start and end waypoints, set in 'world'.
    //  Vector2 is a Key, WavePoint is the value. 'grid' is the name.
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Vector2Int[] directions = {
        Vector2Int.up, // Up
        Vector2Int.right, //Right
        Vector2Int.down, //Down
        Vector2Int.left //Left
    };

    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
    }

    private void ColorStartAndEnd()
    {
        startWayPoint.SetTopColor(Color.cyan);
        endWayPoint.SetTopColor(Color.green);
    }
    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>(); //World of Cubes (waypoint) loading into dictionairy (co-ordinates)
        foreach (Waypoint waypoint in waypoints) // For each Cube
        {
            var gridPos = waypoint.getGridPos(); //This cube + Grid Positioning
            if (grid.ContainsKey(gridPos)) // If the cube has a grid positioning the same as another key cube positioning
            {
                Debug.LogWarning("Skipping overlapping block " + waypoint); //Alert a warning
            }
            else 
            {
                grid.Add(gridPos, waypoint); //Else, add the cube onto the number of cube objects in the dictionairy.
            }
        }
        print("Loaded " + grid.Count + " blocks");
    }
}
