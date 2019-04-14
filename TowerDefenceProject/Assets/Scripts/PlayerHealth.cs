using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] int healthDecrease = 5;
    [SerializeField] Text healthText;
    [SerializeField] AudioClip playerDamagedSound;

    enum State {Alive, Dead}
    State state = State.Alive;

    // Start is called before the first frame update

    private void Start()
    {
        healthText.text = "Health: " + health.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().PlayOneShot(playerDamagedSound);
        health = health - healthDecrease;
        healthText.text = "Health: " + health.ToString();
        if (health <= 0)
        {
            Destroy(gameObject);
            LoadNextScene();
        }
    }
    private void LoadNextScene()
    {
        SceneManager.LoadScene(3);
    }
}
