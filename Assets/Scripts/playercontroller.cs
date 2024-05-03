using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playercontroller : MonoBehaviour
{
    private int count;

    public Text countText;
    public GameObject winTextObject;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;

        SetCountText();
        winTextObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 64)
        {
            winTextObject.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // deactivate an object when a player GameObject collides a cube object and increase count by 1
        if(other.gameObject.CompareTag("pickup"))
        {
            other.gameObject.SetActive(false);
            count += 1;

            SetCountText();
        }
    }
}
