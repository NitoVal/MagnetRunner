using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpBehavior : MonoBehaviour
{
    [SerializeField] TutorialManager tutorialManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        tutorialManager.ShowTutorial("AD");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        tutorialManager.HideTutorial();
    }
}
