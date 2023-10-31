using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TropheeRecompense : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Le joueur a touché le trophée, donc le niveau est terminé.
            // Afficher un message "Well done !" pour savoir que ça marche bien
            Debug.Log("Well done !");

            // Activer le texte "Well done!" si la référence est correctement assignée
            //if (WellDoneText != null)
            //{
            //    WellDoneText.gameObject.SetActive(true);
            //}

            // Peut-être afficher un écran de fin

            // Désactiver le GameObject du trophée pour éviter les collisions répétées.
            gameObject.SetActive(false);
        }
    }
 }
