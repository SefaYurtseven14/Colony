using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{

    RaycastHit hit;
    private Vector3 targetPosition;                     //mouse left button clicked position for object movement

    private string[] selectedObject = null;

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
                if (hit.collider.tag == "PlayerShip")
                {
                    selectedObject = new string[2];
                    selectedObject[0] = hit.collider.tag;
                    selectedObject[1] = hit.collider.name;
                }
                else
                {
                    selectedObject = null;
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            targetPosition = hit.point;
        }

    }
    public string[] SelectedObject()
    {
        return selectedObject;
    }
    public Vector3 GetTargetPosition()
    {
        return targetPosition;
    }
    public void SetTargetPositionZero()
    {
        targetPosition = Vector3.zero;
    }

}
