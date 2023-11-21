using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private TutorialPopUp[] popUps;

    public void ShowTutorial(string nomDuPopUp)
    {
        foreach (TutorialPopUp tutorial in popUps)
        {
            if (tutorial.nomDuPopUp == nomDuPopUp)
            {
                tutorial.popUp.SetActive(true);
            }
        }
    }
}

[System.Serializable]
public struct TutorialPopUp
{
    public string nomDuPopUp;
    public GameObject popUp;
}
