using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menu;
    public GameObject settings;
    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioClip pressSound;
    public void StartPlay()
    {
        Debug.Log("Start pressed!");
        Play();
        SceneManager.LoadScene("FirstLevel");
        //SceneManager.LoadScene(2);
    }

    public void SettingsPressed()
    {
        Play();
        Debug.Log("Settings pressed!");
        //this.gameObject.SetActive(false);
        menu.SetActive(false);
        settings.SetActive(true);

    }
    public void ExitPressed()
    {
        Play();
        Application.Quit();
        Debug.Log("Exit pressed!");
    }

    public void Play() =>soundSource.PlayOneShot(pressSound);
}
