using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [Range(1f, 20f)]
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyParentTransform;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemies());
    }

    IEnumerator RepeatedlySpawnEnemies()
    {
        while (true) // f
            {
                var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                newEnemy.transform.parent = enemyParentTransform;
                yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}