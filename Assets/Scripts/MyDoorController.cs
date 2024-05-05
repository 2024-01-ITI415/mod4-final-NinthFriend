using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyDoorController : MonoBehaviour
{
    private Animator doorAnim;
    private bool doorOpen = false;

    [Header("Audio")]
    [SerializeField] private AudioSource doorOpenAudioSource = null;
    [SerializeField] private float openDelay = 0;
    [Space(10)]
    [SerializeField] private AudioSource doorCloseAudioSource = null;
    [SerializeField] private float closeDelay = 0.8f;

    private void Awake()
    {
        doorAnim = gameObject.GetComponent<Animator>();
    }

    public void PlayAnimation()
    {
        if(!doorOpen)
        {
            doorAnim.Play("door open", 0, 0.0f);
            doorOpen = true;
            doorOpenAudioSource.PlayDelayed(openDelay);
        }
        else
        {
            doorAnim.Play("door close", 0, 0.0f);
            doorOpen = false;
            doorCloseAudioSource.PlayDelayed(closeDelay);
        }
    }
}
