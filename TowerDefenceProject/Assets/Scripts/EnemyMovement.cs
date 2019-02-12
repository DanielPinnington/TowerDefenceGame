using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //List instead of Array as it's not a fixed size, more flexibility, easy to use.
    // Start is called before the first frame update
    void Start()
    {
        PathFinder pathfinder = FindObjectOfType<PathFinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowingPath(path));
        //StartCoroutine(FollowingPath()); //Calls Coroutine method
}
    IEnumerator FollowingPath(List <Waypoint> path) //Inumerator == Coroutine
    {
        print("Starting patrol...");
        foreach(Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position; //Every second, move enemy waypoint position, to next cube.
            yield return new WaitForSeconds(1f); //Yield this, and wait for 1 second. Then carry on.
        }
       print("Ending patrol");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
