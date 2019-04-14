using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{   
    //Allows start and end waypoints, set in 'world'.
    //  Vector2 is a Key, WavePoint is the value. 'grid' is the name.
    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    [SerializeField] bool isRunning = true; //State to check if it's running. Will stop when algorithm stops.
    Waypoint searchCenter; //current searchCenter
    public Waypoint startWayPoint, endWayPoint;
    private List<Waypoint> path = new List<Waypoint>(); //make private later

    Vector2Int[] directions = {
        Vector2Int.up, // Up
        Vector2Int.right, //Right
        Vector2Int.down, //Down
        Vector2Int.left //Left
    };

    public List<Waypoint> GetPath()
    {
        if (path.Count == 0)
        {
            CalcPath();
        }
            return path;
    }

    private void CalcPath()
    {
        LoadBlocks();
        //ExploreNeighbour();
        BreadthFirstSearch();
        CreatePath();
    }
    private void CreatePath()
    {
        SetAsPath(endWayPoint);
        Waypoint previous = endWayPoint.exploredFrom;
        while(previous != startWayPoint)
        {
            //add intermediate waypoints
            SetAsPath(previous); //moving backwards through list
            previous = previous.exploredFrom; // isPlaceable = false, can't place blocks on previous.
        }
        SetAsPath(startWayPoint);
        //add startwaypoint 
        path.Reverse();
        //reverse list
    }

    private void SetAsPath(Waypoint waypoint)
    {
        path.Add(waypoint);
        waypoint.isPlaceable = false;
    }

    private void BreadthFirstSearch() //Queue 
    {
        queue.Enqueue(startWayPoint);
        while (queue.Count > 0 && isRunning) //isrunning to stop infinite loop
        {
            searchCenter = queue.Dequeue();
            HaltIfEnd();
            ExploreNeighbour();
            searchCenter.isExplored = true;
            //explore neighbours
        }
    }
    private void HaltIfEnd()
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
            Vector2Int neighbourCoordinates = searchCenter.getGridPos() + direction;
            //if(grid.ContainsKey(neighbourCoordinates)) //This could be done aswell instead of try/catch
            try
            {
                QueueNewNeighbour(neighbourCoordinates);
            }  //Try-Catch here, incase the co-ordinate block is not in the game, 1,0 for example may not be there so it will cause error.
            catch //This catch will catch the error and do nothing, preventing possible error messages.
            {
                //Do nothing.
            }
        }
    }
    private void QueueNewNeighbour(Vector2Int neighbourCoordinates)
    {
        Waypoint neighbour = grid[neighbourCoordinates];
        if (neighbour.isExplored || queue.Contains(neighbour))
        {

        }
        else
        {
            //neighbour.SetTopColor(Color.blue);  // Check to see if code is working. (need for testing)
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;
            print("Queueing " + neighbour);
        }
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
