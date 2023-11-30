using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PopUpBehavior : MonoBehaviour
{
    [SerializeField] TutorialManager tutorialManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            switch (gameObject.name)
            {
                case "AD":
                    tutorialManager.ShowTutorial("DeplacementHorizontal", true);
                    break;

                case "SPACE":
                    tutorialManager.ShowTutorial("Sauter", true);
                    break;

                case "ITEM":
                    tutorialManager.ShowTutorial("PrendreObjets", true);
                    break;

                case "POLARITY":
                    tutorialManager.ShowTutorial("ChangerPolarite", true);
                    break;

                case "UP":
                    tutorialManager.ShowTutorial("Monter", true);
                    break;

                case "ATTRACT":
                    tutorialManager.ShowTutorial("Attract", true);
                    break;

                case "CROUCH":
                    tutorialManager.ShowTutorial("S'accroupir", true);
                    break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            switch (gameObject.name)
            {
                case "AD":
                    tutorialManager.ShowTutorial("DeplacementHorizontal", false);
                    break;

                case "SPACE":
                    tutorialManager.ShowTutorial("Sauter", false);
                    break;

                case "ITEM":
                    tutorialManager.ShowTutorial("PrendreObjets", false);
                    break;

                case "POLARITY":
                    tutorialManager.ShowTutorial("ChangerPolarite", false);
                    break;

                case "UP":
                    tutorialManager.ShowTutorial("Monter", false);
                    break;

                case "ATTRACT":
                    tutorialManager.ShowTutorial("Attract", false);
                    break;

                case "CROUCH":
                    tutorialManager.ShowTutorial("S'accroupir", false);
                    break;
            }
        }
    }
}