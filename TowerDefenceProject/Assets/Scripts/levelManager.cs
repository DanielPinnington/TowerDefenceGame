using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelManager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
     //   Invoke("LoadGameScene", 2f);
    }
    void Update()
    {
        SceneManager.LoadScene(2);
    }
}
