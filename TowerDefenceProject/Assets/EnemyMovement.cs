using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] List<WavePoint> cubePath; //List instead of Array as it's not a fixed size, more flexibility, easy to use.
    // Start is called before the first frame update
    void Start()
    {
        PrintAllWayPoints();
    }
    private void PrintAllWayPoints()
    {
        foreach(WavePoint waypoint in cubePath)
        {
            print(waypoint.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
