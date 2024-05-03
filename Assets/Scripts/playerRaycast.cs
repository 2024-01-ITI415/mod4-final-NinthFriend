using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRaycast : MonoBehaviour
{
    public GameObject intText;
    public float interactionDistance; 
    public LayerMask layers;

    void Update()
    {
        // Collect information whenever a raycast hits an object
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.forward, out hit, interactionDistance, layers))
        {
            if(hit.collider.gameObject.GetComponent<door>())
            {
                intText.SetActive(true);
                if(Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.gameObject.GetComponent<door>().openClose();
                }
            }
            else
            {
                intText.SetActive(false);
            }
        }
        else
        {
            intText.SetActive(false);
        }
    }
}
