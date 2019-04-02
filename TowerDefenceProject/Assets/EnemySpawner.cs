using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{

    [Range(1f, 20f)]
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyParentTransform;
    [SerializeField] Text spawnedEnemies;
    [SerializeField] AudioClip spawnedEnemySound;
    int score;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemies());
        spawnedEnemies.text = "Enemies: " + score.ToString();
    }

    IEnumerator RepeatedlySpawnEnemies()
    {
        while (true) // f
            {
            addScore();
            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySound);
            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                newEnemy.transform.parent = enemyParentTransform;
                yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
    private void addScore()
    {
        score++;
        spawnedEnemies.text = "Enemies: " + score.ToString();
    }
}