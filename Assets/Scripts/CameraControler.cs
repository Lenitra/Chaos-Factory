using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{    
    private float moveSpeed = 2f;
    private float zoomSpeed = 0.5f;
    private Vector3 prevMousePos;
    private float yZoom = 10f;

    private bool onUI = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // if the clic is on a UI element, don't move the camera
            if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()){
                onUI = true;
                return;
            }
            onUI = false;
            prevMousePos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            // if the clic is on a UI element, don't move the camera
            if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()){
                onUI = true;
                return;
            }
            if (onUI) return;
            Vector3 delta = Input.mousePosition - prevMousePos;
            transform.Translate(-delta.x * moveSpeed * Time.deltaTime, 0, -delta.y * moveSpeed * Time.deltaTime);
            prevMousePos = Input.mousePosition;
        }
        
        // zoom with scroll
        yZoom -= Input.mouseScrollDelta.y * zoomSpeed;


        // reset le y de la caméra
        transform.position = new Vector3(transform.position.x, yZoom, transform.position.z);
    }
}