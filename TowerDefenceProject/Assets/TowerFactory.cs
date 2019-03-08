using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{

    [SerializeField] TowerPan towerPrefab;
    [SerializeField] int towerLimit = 10;
    [SerializeField] Transform towerParentTransform;

    Queue<TowerPan> towerQueue = new Queue<TowerPan>();
    // Start is called before the first frame update

    public void AddTower(Waypoint baseWaypoint)
    {
        int noOfTowers = towerQueue.Count;

        if (noOfTowers < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveTower(baseWaypoint);
        }
    }
    private void MoveTower(Waypoint newbaseWaypoint)
    {
        //Take bottom tower off queue
        var oldTower = towerQueue.Dequeue();
        //Set the placeable flags
        oldTower.baseWaypoint.isPlaceable = true; //the block is now free again
        newbaseWaypoint.isPlaceable = false; //Flase after its not free again
        //Set basewaypoint
        oldTower.baseWaypoint = newbaseWaypoint;
        //Put the old tower back on the top of the queue
        oldTower.transform.position = newbaseWaypoint.transform.position;
        towerQueue.Enqueue(oldTower);
    }
    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        var newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        newTower.transform.parent = towerParentTransform;
        baseWaypoint.isPlaceable = false;

        newTower.baseWaypoint = baseWaypoint;
        baseWaypoint.isPlaceable = false; //not placeable on same square after its placed
        towerQueue.Enqueue(newTower);
        //put new tower on queue
    }
}
