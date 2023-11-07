using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    bool isPaused;
    public GameObject pauseMenuCanvas;
    public GameObject pauseCanvas;
    public GameObject optionMenuCanvas;

    private void Awake()
    {
        isPaused = false;
        Time.timeScale = 1.0f;
        InputManager.onPause += PauseGame;
    }
    private void OnDisable()
    {
        InputManager.onPause -= PauseGame;
    }

    public void PauseGame()
    {
        if (!isPaused)
        {
            Time.timeScale = 0f;
            isPaused = true;
            pauseMenuCanvas.SetActive(isPaused);
            pauseCanvas.SetActive(isPaused);
            optionMenuCanvas.SetActive(!isPaused);
        }
        else
        {
            Time.timeScale = 1f;
            isPaused = false;
            pauseMenuCanvas.SetActive(isPaused);
            pauseCanvas.SetActive(isPaused);
            optionMenuCanvas.SetActive(!isPaused);
        }
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
