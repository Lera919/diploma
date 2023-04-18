using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    private bool isFullScreen = false;

    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioClip pressSound;
    public void FullScreenToggle()
    {

        soundSource.PlayOneShot(pressSound);
        isFullScreen = !isFullScreen;
        Screen.fullScreen = isFullScreen;
    }
}
