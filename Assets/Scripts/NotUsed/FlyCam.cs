using UnityEngine;
using System.Collections;

public class FlyCam : MonoBehaviour
{



    public float cameraSensitivity = 90;
    public float climbSpeed = 4;
    public float normalMoveSpeed = 10;
    public float slowMoveFactor = 0.25f;
    public float fastMoveFactor = 3;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    private float mauseScrollSpeed = 10000f;
    private bool colliderDisable = true;
    void Start()
    {
        Screen.lockCursor = true;
    }

    void Update()
    {
        Vector3 pos = transform.position;
        rotationX += Input.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime;
        rotationY += Input.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime;
        rotationY = Mathf.Clamp(rotationY, -90, 90);

        transform.localRotation = Quaternion.AngleAxis(rotationX, Vector3.up);
        transform.localRotation *= Quaternion.AngleAxis(rotationY, Vector3.left);

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            pos += transform.forward * (normalMoveSpeed * fastMoveFactor) * Input.GetAxis("Vertical") * Time.deltaTime;
            pos += transform.right * (normalMoveSpeed * fastMoveFactor) * Input.GetAxis("Horizontal") * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            pos += transform.forward * (normalMoveSpeed * slowMoveFactor) * Input.GetAxis("Vertical") * Time.deltaTime;
            pos += transform.right * (normalMoveSpeed * slowMoveFactor) * Input.GetAxis("Horizontal") * Time.deltaTime;
        }
        else
        {
            pos += transform.forward * normalMoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
            pos += transform.right * normalMoveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
        }


        if (Input.GetKey(KeyCode.Q)) { transform.position += transform.up * climbSpeed * Time.deltaTime; }
        if (Input.GetKey(KeyCode.E)) { transform.position -= transform.up * climbSpeed * Time.deltaTime; }


        if (colliderDisable)
        {
            transform.position = pos;
        }

        if (Input.GetKeyDown(KeyCode.End))
        {
            Screen.lockCursor = (Screen.lockCursor == false) ? true : false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            colliderDisable = true;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        colliderDisable = false;
    }

}