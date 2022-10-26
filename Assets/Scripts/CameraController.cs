using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f;
    public float panBorderThickness = 10f;
    public float scrollSpeed = 5f;
    [Header("Camera Boundary Constraints")]
    public float minY = 10f;
    public float maxY = 100f;
    public float minX = -20f;
    public float maxX = 97f;
    public float minZ = -90f;
    public float maxZ = 0f;
    [Header("Camera Rotation Constraints")]
    public float minRotation = 45f;
    public float maxRotation = 75f;

    private bool mouseMovement = false;

    // Basic camera movement
    void Update()
    {
        if (GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }

        if (Input.GetKeyDown(KeyCode.C)) { mouseMovement = !mouseMovement; }

        if (mouseMovement)
        {
            if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
            {
                transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
            {
                transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
            {
                transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
            {
                transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
            }
        }
        else
        {
            if (Input.GetKey("w"))
            {
                transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey("s"))
            {
                transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey("d"))
            {
                transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
            }
            if (Input.GetKey("a"))
            {
                transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
            }
        }

        // Scroll to zoom in
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        // Rotate the camera based on the y value
        float rotX;
        // Normalize the ratio of pos.y such that 0.0 = minY and 1.0 = maxY
        float yRatio = (pos.y - minY) / (maxY - minY);
        // Re-normalize the yRatio such that 0.0 = minRotation and 1.0 = maxRotation
        rotX = minRotation + ((maxRotation - minRotation) * yRatio);
        rotX = Mathf.Clamp(rotX, minRotation, maxRotation);      
        transform.rotation = Quaternion.Euler(rotX, 0, 0);

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);

        transform.position = pos;
    }
}
