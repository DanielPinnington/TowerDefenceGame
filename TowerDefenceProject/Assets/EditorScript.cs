using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorScript : MonoBehaviour
{
    // Start is called before the first frame update
    [ExecuteInEditMode]
    void Awake()
    {
        Debug.Log("Editor causes this Awake");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Editor causes this Update");
    }
}
