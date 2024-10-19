using System;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;
    public static Action OnPauseFinished;

    public bool isPaused;
    public GameObject pauseMenu;

    private void Awake()
    {
        instance = this;    
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);

        Time.timeScale = 0;

        isPaused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);

        OnPauseFinished?.Invoke();

        isPaused = false;
    }

}
