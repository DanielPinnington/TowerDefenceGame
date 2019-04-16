using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void ChangeMenuScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
