using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButtonController : MonoBehaviour
{
    [SerializeField] private Animator doorButtonAnim = null;

    private bool doorOpen = false;

    [Header("Animation Names")]
    [SerializeField] private string openAnimationName = "metal door open";
    [SerializeField] private string closeAnimationName = "metal door close";

    [Header("Pause Timer")]
    [SerializeField] private int waitTimer = 1;
    [SerializeField] private bool pauseInteraction = false;

    [Header("Audio")]
    [SerializeField] private AudioSource doorButtonOpenAudioSource = null;
    [SerializeField] private float openDelay = 0;
    [Space(10)]
    [SerializeField] private AudioSource doorButtonCloseAudioSource = null;
    [SerializeField] private float closeDelay = 0.8f;

    private IEnumerator PauseDoorInteraction()
    {
        pauseInteraction = true;
        yield return new WaitForSeconds(waitTimer);
        pauseInteraction = false;
    }

    public void PlayAnimation()
    {
        if(!doorOpen && !pauseInteraction) 
        {
            doorButtonAnim.Play(openAnimationName, 0, 0.0f);
            doorOpen = true;
            StartCoroutine(PauseDoorInteraction());
            doorButtonOpenAudioSource.PlayDelayed(openDelay);
        }

        else if(doorOpen && !pauseInteraction) 
        {
            doorButtonAnim.Play(closeAnimationName, 0, 0.0f);
            doorOpen = false;
            StartCoroutine(PauseDoorInteraction());
            doorButtonCloseAudioSource.PlayDelayed(closeDelay);
        }
    }
}
