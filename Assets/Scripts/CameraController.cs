using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f;
    public float panBorderThickness = 10f;
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 100f;
    public float minX = -20f;
    public float maxX = 97f;
    public float minZ = -80f;
    public float maxZ = 0f;


    
    void Start()
    {
        
    }

    // Basic camera movement
    void Update()
    {
        if (GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }

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

        

        // Scroll to zoom in
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        // Rotate the camera
        // TODO: scale rotation based on Y value
        // I want this to rotate the camera between 45 and 75 degrees
        // dependant on the value of pos.Y, IE between 10 and 100
        // should be something like:
        // rotX = pos.y * (minRot / maxRot))
        float rotX;
        float yRatio = minY / maxY;
        rotX = (pos.y - minY) * yRatio;
        rotX = 80f * rotX;
        Debug.Log(rotX);
        rotX = Mathf.Clamp(rotX, 45f, 80f);
        transform.rotation = Quaternion.Euler(rotX, 0, 0);

        

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.z = Mathf.Clamp(pos.z, minZ, maxZ);

        transform.position = pos;
    }
}
