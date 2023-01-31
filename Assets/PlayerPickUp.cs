using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private LayerMask pickUpLayerMask;
    [SerializeField] private Transform objectGrabPoint;

    private ObjectGrabable objectGrabable;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
             
            float pickUpDistance = 50f;

                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance, pickUpLayerMask))
                {
                    if (raycastHit.transform.TryGetComponent(out ObjectGrabable objectGrabable))
                    {
                        objectGrabable.Grab(objectGrabPoint);
                    }
                } 

                
            
        }
    }
}
