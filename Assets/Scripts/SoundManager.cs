using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSourceCorrect;
    [SerializeField]
    AudioSource audioSourceWrong;

    public void PlayCorrect()
    {
        audioSourceCorrect.Play();
    }

    public void PlayWrong()
    {
        audioSourceWrong.Play();
    }
}
