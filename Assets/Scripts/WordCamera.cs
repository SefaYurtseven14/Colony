using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordCamera : MonoBehaviour {

    //region struct
    public struct BoxLimit
    {
        public float leftLimit;
        public float rightLimit;
        public float topLimit;
        public float bottomLimit;
    }

    // region class variables

    public static BoxLimit cameraLimits = new BoxLimit();
     public static WordCamera Instance;// singolton pattern 

    private float cameraMoveSpeed = 500f;
    private float shiftBonus = 250f;
    private float mouseBoundary = 25f;
    private float mouseScrollSpeed = 10000f;
    private bool mouseScroolController = true;
    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start () {
        // Declare camera limits
        cameraLimits.leftLimit   = 8020f;
        cameraLimits.rightLimit  = -12285f;
        cameraLimits.topLimit    = -22820f;
        cameraLimits.bottomLimit = -2200f;

	}
	
	// Update is called once per frame
	void Update () {
		if(CheckIfUserCameraInput())
        {
            Vector3 cameraDesiredMove = GetDesiredTranslation();
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            if (mouseScroolController || (scroll > 0))
            {
                cameraDesiredMove.y += scroll * mouseScrollSpeed * Time.deltaTime;
                mouseScroolController = true;
            }
            if (!isDesiredPositionOverBoundaries(cameraDesiredMove))
            {
                this.transform.position += cameraDesiredMove;
                //this.transform.Translate(cameraDesiredMove);
            }

        }
	}
    public bool CheckIfUserCameraInput()
    {
        bool keyboardMove;
        bool mouseMove;
        bool canMove;

        if (WordCamera.AreCameraKeyboardButtonsPressed())
        {
            keyboardMove = true;
        }else
            keyboardMove = false;
        

        if (WordCamera.IsMouseScrollActive())
        {
            mouseMove = true;
        }else
            mouseMove = false;

        if (keyboardMove || mouseMove)
        {
            canMove = true;
        }else
            return false;

        return canMove;
    }
    public Vector3 GetDesiredTranslation()
    {
        float moveSpeed = 0f;
        float desiredX = 0f;
        float desiredZ = 0f;

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            moveSpeed = (cameraMoveSpeed + shiftBonus) * Time.deltaTime;
        }else{
            moveSpeed = cameraMoveSpeed * Time.deltaTime;
        }
        // move via keyboard

        if (Input.GetKey(KeyCode.W))
        {
            desiredZ = moveSpeed * -1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            desiredZ = moveSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            desiredX = moveSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            desiredX = moveSpeed * -1;
        }

        return new Vector3(desiredX, 0, desiredZ);

    }

    public bool isDesiredPositionOverBoundaries(Vector3 desiredPosition)
    {
        bool overBoundaries = false;
        if (((this.transform.position.x + desiredPosition.x) > cameraLimits.leftLimit))
        {
            if ((Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.D)))
            {
                overBoundaries = false;
            }else
                overBoundaries = true;
        }
        if ((this.transform.position.x + desiredPosition.x) < cameraLimits.rightLimit)
        {
            if ((Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.A)))
            {
                overBoundaries = false;
            }else
                overBoundaries = true;
        }
        if ((this.transform.position.z + desiredPosition.z) < cameraLimits.topLimit)
        {
            if ((Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.D)))
            {
                overBoundaries = false;
            }
            else
                overBoundaries = true;
        }
        if ((this.transform.position.z + desiredPosition.z) > cameraLimits.bottomLimit)
        {
            if ((Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.A)))
            {
                overBoundaries = false;
            }
            else
                overBoundaries = true;
        }
        return overBoundaries;
    }
    public static bool AreCameraKeyboardButtonsPressed()
    {
        if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.D)))
        {
            return true;
        }else
            return false;
    }
    public static bool IsMouseScrollActive()
    {
        if (true)
        {
            return true;
        }else
            return false;
    }
    private void OnTriggerEnter(Collider other)
    {
        mouseScroolController = false;
    }
}
