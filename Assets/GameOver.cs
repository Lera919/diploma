using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioClip pressSound;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void StartPlay()
    {
        Debug.Log("Start pressed!");
        Play();
        SceneManager.LoadScene(PlayerPrefs.GetString("level"));
    }

    public void Play() => soundSource.PlayOneShot(pressSound);
}
