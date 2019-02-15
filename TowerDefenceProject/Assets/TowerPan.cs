using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPan : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;

    void Update()
    {
        objectToPan.LookAt(targetEnemy.transform.position);
    }
}
