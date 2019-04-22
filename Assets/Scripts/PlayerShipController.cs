using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipController : MonoBehaviour {

    private Vector3 lookAtTarget;
    private Quaternion playerRotation;
    private float speed = 1000;
    private Vector3 targetPosition;
    private bool moveController = false;

    void Awake()
    {
        targetPosition = Vector3.zero;
    }
    private void Update()
    {
        ChangeDirection();
        Move();
    }
    private void Move()
    {
        if (moveController && targetPosition != Vector3.zero)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position,
                targetPosition,
                speed * Time.deltaTime);
        }
        if (this.transform.position == targetPosition)
        {
            moveController = false;
            targetPosition = Vector3.zero;
        }
    }
    private void ChangeDirection()
    {
        if (moveController)
        {
            this.transform.LookAt(targetPosition);
        }
    }
    public void SetTargetPosition(Vector3 mouseHitPosition)
    {
        targetPosition = mouseHitPosition;
    }
    public void SetMoveControllerTrue()
    {
        moveController = true;
    }
}
