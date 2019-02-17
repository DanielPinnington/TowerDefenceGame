using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnParticleCollision(GameObject other)
    {
        print("I'm hit!");
    }
}
