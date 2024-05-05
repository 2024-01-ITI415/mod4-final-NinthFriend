using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playercontroller : MonoBehaviour
{
    private int count;

    [Header("Text Objects")]
    public Text countText;
    public GameObject winTextObject;

    [Header("Audio")]
    [SerializeField] public AudioSource pickUpAudioSource = null;
    [SerializeField] public float pickUpDelay = 0.2f;

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

        if (count >= 20)
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
            pickUpAudioSource.PlayDelayed(pickUpDelay);
            count += 1;

            SetCountText();
        }
    }
}
