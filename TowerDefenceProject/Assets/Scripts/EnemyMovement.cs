using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<WavePoint> cubePath; //List instead of Array as it's not a fixed size, more flexibility, easy to use.
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FollowingPath()); //Calls Coroutine method
    }
    IEnumerator FollowingPath() //Inumerator == Coroutine
    {
        print("Starting patrol...");
        foreach(WavePoint waypoint in cubePath)
        {
            transform.position = waypoint.transform.position; //Every second, move enemy waypoint position, to next cube.
            print("Visiting: " + waypoint);
            yield return new WaitForSeconds(1f); //Yield this, and wait for 1 second. Then carry on.
        }
        print("Ending patrol");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
