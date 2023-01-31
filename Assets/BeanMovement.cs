using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanMovement : MonoBehaviour
{
    private InputHandler _input;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float rotateSpeed;

    [SerializeField]
    private bool rotateTwoardsMouse;

    [SerializeField]
    private Camera camera;

    private void Awake()
    {
        _input = GetComponent<InputHandler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            OnDestroy();
        }
        else if (other.CompareTag("Boom"))
        {
            OnDestroy();
        }
    }


    private void Update()
    {
        var targetVector = new Vector3(_input.InputVector.x, 0, _input.InputVector.y);

        //Move in the direction your aiming
        var movementVector = MoveTowardsTarget(targetVector);
        if (!rotateTwoardsMouse)
            //Rotate in the direction your traveling
            RotatetwoardMovementVector(movementVector);
        else
            RotatetwoardMouseVector();
    }

    private void RotatetwoardMouseVector()
    {
        Ray ray = camera.ScreenPointToRay(_input.Mouseposition);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance: 300f))
        {

            var target = hitInfo.point;
            target.y = transform.position.y;
            transform.LookAt(target);
        }
    }

    private void RotatetwoardMovementVector(Vector3 movementVector)
    {

        if (movementVector.magnitude == 0)
        {
            return;
        }

        var rotation = Quaternion.LookRotation(movementVector);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed);
    }

    private Vector3 MoveTowardsTarget(Vector3 targetVector)
    {
        var speed = moveSpeed * Time.deltaTime;

        targetVector = Quaternion.Euler(0, camera.gameObject.transform.eulerAngles.y, 0) * targetVector;
        var targetPosition = transform.position + targetVector * speed;
        transform.position = targetPosition;

        return targetVector;
    }

    private void OnDestroy()
    {
        Destroy(gameObject);
    }

}