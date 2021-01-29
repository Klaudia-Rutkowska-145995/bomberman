using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject lostMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameManager.instance.GameIsLost)
        {
            if (GameManager.instance.GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if(GameManager.instance.GameIsLost)
        {
            lostMenuUI.SetActive(true);
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameManager.instance.GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameManager.instance.GameIsPaused = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void NewGame()
    {
        GameManager.instance.GameIsLost = false;
        SceneManager.LoadScene(1);
        lostMenuUI.SetActive(false);
    }
}
