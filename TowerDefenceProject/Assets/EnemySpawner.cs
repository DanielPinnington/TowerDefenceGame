using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [Range(1f, 20f)]
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemyPrefab;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemies());
    }

    IEnumerator RepeatedlySpawnEnemies()
    {
        while (true) // f
            {
                Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}