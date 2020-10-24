using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatformsPivot : MonoBehaviour
{
    [SerializeField] private RotatingPlatforms platform;
    [SerializeField] private GameObject platformPivot;
    [SerializeField] private GameMenager gameMenager;
    public bool pivotPosSet = false;
    
    private void OnMouseDown() {
        if (gameMenager.isRotationActive && !pivotPosSet) {
            if (!platform.hasBeenRotated) {
                Vector2 newPivotPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                platformPivot.transform.position = new Vector3(newPivotPos.x, newPivotPos.y, -1);
                pivotPosSet = true; 
            }
        }
    }
}
