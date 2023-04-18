using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{

    public GameObject menu;
    public GameObject settings;
    public GameObject scoreLablesPane;
    public GameObject crossPane;
    public MouseLook mouseLook;
    
    public bool isPaused { get; private set; } = false;
    public void Start()
    {
        menu.SetActive(false);
        scoreLablesPane.SetActive(true);
        mouseLook = GetComponent<MouseLook>();
       

    }
    public void Update() => Pause();
    void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if (isPaused) 
        {
           Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            menu.SetActive(true);
            scoreLablesPane.SetActive(false);
            crossPane.SetActive(false);
            Time.timeScale = 0;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            menu.SetActive(false);
            settings.SetActive(false);
            scoreLablesPane.SetActive(true);
            crossPane.SetActive(true);
            Time.timeScale = 1;
        }
    }
}
