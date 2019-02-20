using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnParticleCollision(GameObject other)
    {
        EnemyHit();
        if(hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    void EnemyHit()
    {
        hitPoints = hitPoints - 1;
    }

    private void KillEnemy()
    {
        Destroy(gameObject);
    }
}
