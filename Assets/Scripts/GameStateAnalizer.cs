using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameStateAnalizer
{
    public static void GameOver()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        PlayerPrefs.SetString("level", SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("GameOver");
    }

    public static void Win() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
}
