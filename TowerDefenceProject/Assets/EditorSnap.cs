using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class EditorSnap : MonoBehaviour
{
    [SerializeField] float gridSize = 10f;

    void Update()
    {
        Vector3 snapPosition;
        snapPosition.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize; //Takes position, divides by 10 and rounds the X position to nearest number. 
                                                                             //Example: 6 / 10 = 0.6 (RoundToInt = 1)
                                                                             //Finally: 1 * 10f = 10f.
        snapPosition.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;

        transform.position = new Vector3(snapPosition.x, 0f, snapPosition.z);
    }
}
