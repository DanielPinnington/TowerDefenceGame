using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase] //Makes it harder to click on surface children, only allows for click on BASE. IE (Cube)
[RequireComponent(typeof(WavePoint))]
public class CubeEditor : MonoBehaviour
{
    WavePoint wavepoint;
    private void Awake()
    {
        wavepoint = GetComponent<WavePoint>();
    }
    void Update()
    {
        SnapToGrid();
        UpdateLabel();
    }
    private void SnapToGrid()
    {
        int gridSize = wavepoint.getGridSize();
        transform.position = new Vector3(wavepoint.GetGridPos().x, 0f, wavepoint.GetGridPos().y); //2 Components, x & y.
    }

    private void UpdateLabel() {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        int gridSize = wavepoint.getGridSize();
        string labelText = wavepoint.GetGridPos().x / gridSize + "," + wavepoint.GetGridPos().y / gridSize; //TextMesh.text == X & Y Positioning of Cube.
       // textMesh.text = labelText;
        gameObject.name = labelText;
    }
}
