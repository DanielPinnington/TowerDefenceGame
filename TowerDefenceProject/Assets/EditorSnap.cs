﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class EditorSnap : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("Editor causes this Awake");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 snapPosition;
        snapPosition.x = Mathf.RoundToInt(transform.position.x / 10f) * 10f; //Takes position, divides by 10 and rounds the X position to nearest number. 
        //Example: 6 / 10 = 0.6 (RoundToInt = 1)
        //Finally: 1 * 10f = 10f.
        snapPosition.z = 0f;
        transform.position = new Vector3(snapPosition.x, 0f, snapPosition.z);
    }
}
