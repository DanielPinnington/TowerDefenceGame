using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase] //Makes it harder to click on surface children, only allows for click on BASE. IE (Cube)
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{

    Waypoint waypoint;
    private void Awake()
    {
        waypoint = GetComponent<Waypoint>();
    }
    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }
    private void SnapToGrid() //private later
    {
        int gridSize = waypoint.getGridSize();
        transform.position = new Vector3(waypoint.getGridPos().x * gridSize, 0f, waypoint.getGridPos().y * gridSize); //2 Components, x & y.
    }

    private void UpdateLabel() {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        int gridSize = waypoint.getGridSize();
        string labelText = waypoint.getGridPos().x + "," + waypoint.getGridPos().y; //TextMesh.text == X & Y Positioning of Cube.
       // textMesh.text = labelText
        gameObject.name = labelText;
    }
}
