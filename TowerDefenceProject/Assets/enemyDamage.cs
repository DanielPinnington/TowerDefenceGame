using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{   
    public GameObject FloatingText;
    [SerializeField] int hitPoints = 10;
    [SerializeField] int scoreTotal = 0;
    [SerializeField] int scoreKill = 10;
    [SerializeField] ParticleSystem hitParticlePrefabs;
    [SerializeField] ParticleSystem deathParticlePrefab;
    // Start is called before the first frame update
    void Start()
    {

    } 

    private void OnParticleCollision(GameObject other)
    {
        EnemyHit();
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }
    void EnemyKill()
    {
        scoreTotal = scoreTotal + 10;
    }

    void EnemyHit()
    {
        if (FloatingText && hitPoints > 0)
        {
            ShowFloatingText();
        }

        hitPoints = hitPoints - 1;
        //hitParticlePrefabs.Play();
    }

    void ShowFloatingText()
    {
        var go = Instantiate(FloatingText, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMesh>().text = hitPoints.ToString();
    }
    private void KillEnemy()
    {
        var delay = 1f; //Delay of 2 seconds
        var deathParticle = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        deathParticlePrefab.Play();
        Destroy(gameObject);
        EnemyKill();
        Destroy(deathParticle.gameObject, delay);
    }
}
