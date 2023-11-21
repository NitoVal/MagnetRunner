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
    private void Update()
    {
        if (isPaused)
        {
            Time.timeScale = 0f;
            pauseMenuCanvas.SetActive(isPaused);
            pauseCanvas.SetActive(isPaused);
            optionMenuCanvas.SetActive(!isPaused);
        }
        else
        {
            Time.timeScale = 1f;
            pauseMenuCanvas.SetActive(isPaused);
            pauseCanvas.SetActive(isPaused);
            optionMenuCanvas.SetActive(!isPaused);
        }
    }
    public void PauseGame()
    {
        if (isPaused)
            isPaused = false;
        else
            isPaused = true;
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
