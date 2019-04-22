using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    private  GameObject mouseControllerObject;
    private MouseController mouse;
    private void Awake()
    {
        mouseControllerObject = GameObject.Find("MouseController");
        mouse = mouseControllerObject.GetComponent<MouseController>();

    }
    void Update () {
        ObjectMovementController();
    }
    void ObjectMovementController()
    {

        var selectedObject = mouse.SelectedObject();
        if (selectedObject != null)
        {
            if (selectedObject[0] == "PlayerShip")
            {
                GameObject playerShipObject = GameObject.Find(selectedObject[1]);
                PlayerShipController ship = playerShipObject.GetComponent<PlayerShipController>();
                if (mouse.GetTargetPosition() != Vector3.zero)
                {
                    ship.SetMoveControllerTrue();
                    ship.SetTargetPosition(mouse.GetTargetPosition());
                    mouse.SetTargetPositionZero();
                }
            }
        }

    }
}
