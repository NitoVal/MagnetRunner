using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    bool isPaused = false;
    public GameObject pauseMenuCanvas;
    public GameObject pauseCanvas;
    public GameObject optionMenuCanvas;
    public GameObject winUI;
    public GameObject loseUI;
    public GameObject objectiveUI;
    public GameObject timerUI;
    public GameObject collectibleUI;

    private void Awake()
    {
        isPaused = false;
        Time.timeScale = 1f;
        InputManager.onPause += PauseGame;
    }
    private void OnDisable()
    {
        InputManager.onPause -= PauseGame;
    }
    public void PauseGame()
    {
        if (winUI.activeSelf || loseUI.activeSelf)

            return;
        if (isPaused)
        {
            isPaused = false;
            Time.timeScale = 1f;
            pauseMenuCanvas.SetActive(isPaused);
            pauseCanvas.SetActive(isPaused);
            optionMenuCanvas.SetActive(!isPaused);
            timerUI.SetActive(!isPaused);
            objectiveUI.SetActive(!isPaused);
            collectibleUI.SetActive(!isPaused);
        }
        else
        {
            isPaused = true;
            Time.timeScale = 0f;
            pauseMenuCanvas.SetActive(isPaused);
            pauseCanvas.SetActive(isPaused);
            optionMenuCanvas.SetActive(!isPaused);
            timerUI.SetActive(!isPaused);
            objectiveUI.SetActive(!isPaused);
            collectibleUI.SetActive(!isPaused);
        }

    }
    public void RestartLevel() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        isPaused = false;
        Time.timeScale = 1f;
    }
    public void MainMenu(){ SceneManager.LoadScene(0); }
}
