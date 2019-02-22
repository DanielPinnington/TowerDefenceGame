using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public GameObject FloatingText;
    [SerializeField] int hitPoints = 10;

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
    }

    void ShowFloatingText()
    {
        var go = Instantiate(FloatingText, transform.position, Quaternion.identity, transform);
        go.GetComponent<TextMesh>().text = hitPoints.ToString();
    }
    private void KillEnemy()
    {
        Destroy(gameObject);
    }
}
