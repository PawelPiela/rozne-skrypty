using UnityEngine;
using System.Collections;

public class RotatingPlatforms : MonoBehaviour {

    [SerializeField] private GameMenager gameMenager;
    [SerializeField] private GameObject platformPivot;
    [SerializeField] private RotatingPlatformsPivot platformPivotScript;

    [SerializeField] float rotationSpeed = 1500;
    [SerializeField] float mouseInputMultiplier = 2f;
    public bool hasBeenRotated = false;
    private float inputX;
    private bool dragging = false;  

    private void OnMouseDrag() {
        dragging = true;
    }
    void Update() { 
        if (gameMenager.isRotationActive && platformPivotScript.pivotPosSet) {
            if (Input.GetMouseButtonUp(0)) 
                dragging = false;
            if (dragging) {
                inputX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;               
                transform.RotateAround(platformPivot.transform.position, -Vector3.forward, (inputX * mouseInputMultiplier));
                hasBeenRotated = true;
            }
        }
    }
}



