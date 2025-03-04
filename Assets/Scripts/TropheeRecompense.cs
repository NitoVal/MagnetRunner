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
                // Le joueur a touché le trophée, donc le niveau est terminé.
                // Afficher un message "Well done !" pour savoir que ça marche bien
                //Activer le texte "Well done!" si la référence est correctement assignée
                if (WellDoneText != null)
                {
                    WellDoneText.gameObject.SetActive(true);
                }
                Time.timeScale = 0f;
                gameObject.SetActive(false);
            }
    }
 }
