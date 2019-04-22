using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovementController : MonoBehaviour {

    private Vector3 Distance;
    private float PositionX;
    private float PositionY;
    private bool isObjectDroped = false;
    private bool temp = false;


    private GameObject mouseControllerObject;
    private MouseController mouse;
    private Vector3 mousePosition;
    private void Awake()
    {
        mouseControllerObject = GameObject.Find("MouseController");
        mouse = mouseControllerObject.GetComponent<MouseController>();

    }

    // Start is called before the first frame update
    void Start()
    {
        Distance = Camera.main.WorldToScreenPoint(transform.position);
        PositionX = Input.mousePosition.x - Distance.x;
        PositionY = Input.mousePosition.y - Distance.y;
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = mouse.GetMousePosition();

        if (Input.GetMouseButton(0))
        {
            isObjectDroped = true;

            Debug.Log("2");
            GlobalVariables.controller = 1;
            GlobalVariables.buttonActive = false;

        }
        if (isObjectDroped == false && GlobalVariables.buttonActive)
        {
            Debug.Log("1");
            Vector3 CurrentPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Distance.z);
            Vector3 WorldPosition = Camera.main.ScreenToWorldPoint(CurrentPosition);
            transform.position = mousePosition;
        }

    }
}

