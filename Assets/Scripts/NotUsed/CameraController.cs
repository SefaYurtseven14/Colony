    using UnityEngine;

public class CameraController : MonoBehaviour {

    private float panSpeed = 20f; // Camera move speed in per second
    public Vector2 panLimit;

    private float mauseScrollSpeed = 10000f;

    private float speedH = 2f;
    private float speedV = 2f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    private bool objectNotDetected, mapWallNotDetection = true;
    private char lastKey, presentKey;


    void Update()
    {

        Vector3 pos = transform.position;
        if (Input.GetKey("w"))
        {
            pos.z -= panSpeed + Time.deltaTime;
            presentKey = 'w';
        }
        if (Input.GetKey("s"))
        {
            pos.z += panSpeed + Time.deltaTime;
            presentKey = 's';
        }
        if (Input.GetKey("a"))
        {
            pos.x += panSpeed + Time.deltaTime;
            presentKey = 'a';
        }
        if (Input.GetKey("d"))
        {
            pos.x -= panSpeed + Time.deltaTime;
            presentKey = 'd';
        }
        float lastDirection = 0;
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        lastDirection = scroll;
        if (objectNotDetected)
        {
            pos.y += scroll * mauseScrollSpeed * Time.deltaTime;
        }
        if (lastDirection > 0)
        {
            objectNotDetected = true;
        }
        //yaw += speedH * Input.GetAxis("Mouse X");
        //pitch -= speedV * Input.GetAxis("Mouse Y");
        //pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        //pos.z = Mathf.Clamp(pos.x, -panLimit.y, panLimit.y);
        //transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        if (lastKey != presentKey)
        {
            mapWallNotDetection = true;
        }
        if (mapWallNotDetection)
        {
            transform.position = pos;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        objectNotDetected = false;
        mapWallNotDetection = false;
        lastKey = presentKey;
    }

}
