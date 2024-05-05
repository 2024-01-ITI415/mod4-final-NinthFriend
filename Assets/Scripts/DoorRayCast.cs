using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorRayCast : MonoBehaviour
{
    [SerializeField] private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName = null;

    private MyDoorController door;
    private DoorButtonController doorButton;

    [SerializeField] private KeyCode openDoorKey = KeyCode.E;

    [SerializeField] private GameObject intButton;
    private bool isCrosshairActive;
    private bool doOnce;

    private void Start()
    {
        intButton.SetActive(false);
    }
    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

        if(Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
        {
            if(hit.collider.CompareTag("InteractiveDoor"))
            {
                if(!doOnce)
                {
                    door = hit.collider.gameObject.GetComponent<MyDoorController>();
                    CrosshairChange(true);
                }

                isCrosshairActive = true;
                doOnce = true;

                if(Input.GetKeyDown(openDoorKey))
                {
                    door.PlayAnimation();
                }
            }

            if(hit.collider.CompareTag("InteractiveButton"))
            {
                if(!doOnce)
                {
                    doorButton = hit.collider.gameObject.GetComponent<DoorButtonController>();
                    CrosshairChange(true);
                }

                isCrosshairActive = true;
                doOnce = true;

                if(Input.GetKeyDown(openDoorKey))
                {
                    doorButton.PlayAnimation();
                }
            }
        }

        else
        {
            if(isCrosshairActive)
            {
                CrosshairChange(false);
                doOnce = false;
            }
        }
    }

    void CrosshairChange(bool on)
    {
        if(on && !doOnce)
        {
            intButton.SetActive(true);
        }
        else
        {
            intButton.SetActive(false);
        }
    }
}
