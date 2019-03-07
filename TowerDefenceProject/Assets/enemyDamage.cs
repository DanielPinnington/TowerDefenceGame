using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{   
    public GameObject FloatingText;
    [SerializeField] int hitPoints = 10;
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
        var delay = 0.5f; //Delay of 2 seconds
        var deathParticle = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        deathParticlePrefab.Play();
        Destroy(deathParticle);
        Destroy(gameObject, delay);
        print("Enemy Destroyed");
    }
}
