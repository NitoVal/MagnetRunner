using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // When Play Game button is clicked
    public void PlayGame()
    {
        // Move to the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // When Quite Game button is clicked
    public void QuitGame()
    {
        // Close the application
        Application.Quit();
    }
}
