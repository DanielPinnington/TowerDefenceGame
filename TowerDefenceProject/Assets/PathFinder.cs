using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Waypoint startWayPoint, endWayPoint; //Allows start and end waypoints, set in 'world'.
    //  Vector2 is a Key, WavePoint is the value. 'grid' is the name.
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    bool isRunning = true; //State to check if it's running. Will stop when algorithm stops.

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
        ExploreNeighbour();
        Pathfind();
    }

    private void Pathfind() //Queue 
    {
        queue.Enqueue(startWayPoint);
        while (queue.Count > 0 && isRunning) //isrunning to stop infinite loop
        {
            var searchCenter = queue.Dequeue();
            HaltIfEnd(searchCenter);
            //explore neighbours
        }
    }
    private void HaltIfEnd(Waypoint searchCenter)
    {
        if(searchCenter == endWayPoint)
        {
            print("Searching from end node, therefore stopping!");
            isRunning = false;
        }
    }

    private void ExploreNeighbour()
    {
        if (!isRunning)
        {
            return;
        }
        foreach(Vector2Int direction in directions)
        {
            Vector2Int explorationCoordinate = startWayPoint.getGridPos() + direction;

            try
            {
                grid[explorationCoordinate].SetTopColor(Color.blue); // Check to see if code is working. (need for testing)
            }  //Try-Catch here, incase the co-ordinate block is not in the game, 1,0 for example may not be there so it will cause error.
            catch //This catch will catch the error and do nothing, preventing possible error messages.
            {
                //Do nothing.
            }
        }
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
