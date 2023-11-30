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
        InputManager.onPause += PauseGame;
    }
    private void OnDisable()
    {
        InputManager.onPause -= PauseGame;
    }
    public void PauseGame()
    {
        if (isPaused)
        {
            isPaused = false;
            Time.timeScale = 1f;
            pauseMenuCanvas.SetActive(isPaused);
            pauseCanvas.SetActive(isPaused);
            optionMenuCanvas.SetActive(!isPaused);
        }
        else
        {
            isPaused = true;
            Time.timeScale = 0f;
            pauseMenuCanvas.SetActive(isPaused);
            pauseCanvas.SetActive(isPaused);
            optionMenuCanvas.SetActive(!isPaused);
        }

    }
    public void RestartLevel() { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }
    public void MainMenu(){ SceneManager.LoadScene(0); }
}
