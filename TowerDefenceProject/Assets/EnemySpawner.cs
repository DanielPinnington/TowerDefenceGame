using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemies());
    }
    IEnumerator RepeatedlySpawnEnemies()
    {
        while (true) //forever
        {
            print("Spawning");
            yield return new WaitForSeconds(secondsBetweenSpawns); //Wait __ seconds
        }
    }
}
