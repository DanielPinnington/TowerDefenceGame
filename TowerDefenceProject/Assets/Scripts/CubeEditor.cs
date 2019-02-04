using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase] //Makes it harder to click on surface children, only allows for click on BASE. IE (Cube)
public class CubeEditor : MonoBehaviour
{
    [SerializeField] [Range(1f, 20f)] float gridSize = 10f;

    TextMesh textMesh;

    void Update()
    {
        Vector3 snapPosition;
        snapPosition.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize; //Takes position, divides by 10 and rounds the X position to nearest number. 
                                                                             //Example: 6 / 10 = 0.6 (RoundToInt = 1)
                                                                             //Finally: 1 * 10f = 10f.
        snapPosition.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;
        transform.position = new Vector3(snapPosition.x, 0f, snapPosition.z);

        textMesh = GetComponentInChildren<TextMesh>();
        string labelText = snapPosition.x / gridSize + "," + snapPosition.z / gridSize; //TextMesh.text == X & Y Positioning of Cube.
       // textMesh.text = labelText;
        gameObject.name = labelText;
    }
}
