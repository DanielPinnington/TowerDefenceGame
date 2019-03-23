using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float movementPeriod = .5f;
    [SerializeField] ParticleSystem goalParticle;
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
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(movementPeriod);
        }
        ExplodeEnemy();
        print("hitTower");
    }
    private void ExplodeEnemy()
    {
       // var delay = 1.2f; //Delay of 2 seconds
       // var deathParticle = Instantiate(goalParticle, transform.position, Quaternion.identity);
       // deathParticle.Play();
       // Destroy(deathParticle.gameObject, delay);
        Destroy(gameObject);
        print("Enemy Destroyed");
    }
}