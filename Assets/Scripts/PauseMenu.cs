using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    bool isPaused;
    public GameObject pauseCanvas;
    private void Awake()
    {
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
            pauseCanvas.SetActive(isPaused);
        }
        else
        {
            Time.timeScale = 1f;
            isPaused = false;
            pauseCanvas.SetActive(isPaused);
        }
    }

    public void RestartLevel(int sceneIndex)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
