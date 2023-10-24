using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelLoader : MonoBehaviour
{
    [Header("Components needed")]
    [SerializeField] private Animator transition;

    [Header("Variables")]
    [SerializeField] private float transitionTime = 1f;

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    // Coroutine
    IEnumerator LoadLevel(int levelIndex)
    {
        // Play the animation
        transition.SetTrigger("Start");

        // Wait before starting the scene to give time for the animation to finish
        yield return new WaitForSeconds(transitionTime);

        // Load the scene
        SceneManager.LoadScene(levelIndex);
    }
}
