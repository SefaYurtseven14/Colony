using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{

    RaycastHit hit;


    public static GameObject currentlySelectedUnit;

    private Vector3 targetPosition;
    private Vector3 lookAtTarget;
    private Quaternion playerRotation;
    private float speed = 1000;
    private float rotSpeed = 500;
    private bool moveController = false;

    void Awake()
    {
        targetPosition = Vector3.zero;
    }
    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            // mouse left button down
            if (Input.GetMouseButtonDown(0))
            {

                // in the next I will have to write here other selectable objects
                if (hit.collider.tag == "Ship")
                {
                    currentlySelectedUnit = GameObject.Find(hit.collider.name);
                    
                }
                else
                {
                    currentlySelectedUnit = null;
                }
                Debug.Log(currentlySelectedUnit.name);
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            targetPosition = hit.point;
            currentlySelectedUnit.transform.LookAt(targetPosition);
            moveController = true;



        }
        if (moveController)
        {
            Move();
        }

    }
    void Move()
    {
        currentlySelectedUnit.transform.position = Vector3.MoveTowards(currentlySelectedUnit.transform.position,
            targetPosition,
            speed * Time.deltaTime);
        if (currentlySelectedUnit.transform.position == targetPosition)
        {
            moveController = false;
        }
    }

}
