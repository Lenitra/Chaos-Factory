using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{    
    public float moveSpeed = 5f;
    public float zoomSpeed = 0.5f;
    private Vector3 prevMousePos;
    public float yZoom = 10f;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // Déplacement de la caméra
            Vector3 mousePos = Input.mousePosition;

            if (prevMousePos != Vector3.zero)
            {
                Vector3 deltaPos = mousePos - prevMousePos;

                // Déplacement horizontal
                transform.Translate(Vector3.right * deltaPos.x * moveSpeed * Time.deltaTime, Space.Self);

                // Déplacement vertical
                transform.Translate(Vector3.up * deltaPos.y * moveSpeed * Time.deltaTime, Space.Self);
            }

            prevMousePos = mousePos;
        }
        else if (Input.GetMouseButton(1))
        {
            // Zoom de la caméra
            float zoom = Input.GetAxis("Mouse Y");

            // Zoom avant
            if (zoom < 0)
            {
                transform.Translate(Vector3.forward * zoomSpeed * Time.deltaTime);
            }
            // Zoom arrière
            else if (zoom > 0)
            {
                transform.Translate(Vector3.back * zoomSpeed * Time.deltaTime);
            }
        }
        else
        {
            prevMousePos = Vector3.zero;
        }
        // reset le y de la caméra
        transform.position = new Vector3(transform.position.x, yZoom, transform.position.z);
    }
}