using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] int healthDecrease = 5;
    [SerializeField] Text healthText;
    // Start is called before the first frame update

    private void Start()
    {
        healthText.text = health.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        health = health - healthDecrease;
        healthText.text = health.ToString();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
