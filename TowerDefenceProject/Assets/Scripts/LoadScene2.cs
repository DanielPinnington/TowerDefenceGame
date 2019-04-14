using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene2 : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        Invoke("LoadSecondScene", 2f);
    }

    // Update is called once per frame
    void LoadSecondScene()
    {
        SceneManager.LoadScene(2);
    }
}
