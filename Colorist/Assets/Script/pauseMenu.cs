using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject menuPause;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        menuPause.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        menuPause.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void HomeButt()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        GameIsPaused = false;
    }

    public void restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameIsPaused = false;
    }
}
