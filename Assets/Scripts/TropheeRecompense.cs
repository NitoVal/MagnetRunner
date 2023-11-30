using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TropheeRecompense : MonoBehaviour
{ 
    [SerializeField] TMP_Text WellDoneText;

    private void OnTriggerEnter2D(Collider2D other)
    { 
            if (other.CompareTag("Player"))
            {
                // Le joueur a touch� le troph�e, donc le niveau est termin�.
                // Afficher un message "Well done !" pour savoir que �a marche bien
                //Activer le texte "Well done!" si la r�f�rence est correctement assign�e
                if (WellDoneText != null)
                {
                    WellDoneText.gameObject.SetActive(true);
                }
                Time.timeScale = 0f;
                gameObject.SetActive(false);
            }
    }
 }
