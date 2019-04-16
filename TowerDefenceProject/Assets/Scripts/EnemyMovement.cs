using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float movementPeriod = .5f;
    [SerializeField] ParticleSystem goalParticle;
    float maxSteps;
    //[SerializeField] float maxSteps;
    // Use this for initialization
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        print("Starting patrol...");

        foreach (Waypoint step in path)
        {
            int i = 0;
            float maxSteps = Random.Range(20.0f, 40.0f);

            float stepStageDist = Vector3.Distance(transform.position, step.transform.position) / maxSteps;

            WaitForSeconds wFSDelay = new WaitForSeconds(movementPeriod / maxSteps);

            while (i < maxSteps)
            {
                i++;

                transform.position = Vector3.MoveTowards(transform.position, step.transform.position, stepStageDist);

                yield return wFSDelay;
            }
        }
        ExplodeEnemy();



        //  foreach (Waypoint waypoint in path)
        // {
        //    transform.position = waypoint.transform.position;
        //    yield return new WaitForSeconds(movementPeriod);
        // }
        // ExplodeEnemy();
        // print("hitTower");
    }
    private void ExplodeEnemy()
    {
        var delay = 1.2f; //Delay of 2 seconds
        var deathParticle = Instantiate(goalParticle, transform.position, Quaternion.identity);
        deathParticle.Play();
        Destroy(deathParticle.gameObject, delay);
        Destroy(gameObject);
        print("Enemy Destroyed");
    }
}