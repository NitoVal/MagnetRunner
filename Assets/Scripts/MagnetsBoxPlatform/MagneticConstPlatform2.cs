using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticConstPlatform2 : MonoBehaviour //Script attaché à la plateforme
{

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            gameObject.layer = LayerMask.NameToLayer("N");
      
        }
    }

    private void Awake()
    { 
        ButtonTrigger.onButtonHit += DisableEffectors;
    }
    private void DisableEffectors() //Fonction qui sera appelée pour désactiver Nforce+Sforce et remettre la gravité à neutre
    {
        Effector2D nForceEffector = transform.Find("NForce").GetComponent<Effector2D>();
        if (nForceEffector != null)
        {
            nForceEffector.enabled = false;
        }

        Effector2D sForceEffector = transform.Find("SForce").GetComponent<Effector2D>();
        if (sForceEffector != null)
        {
            sForceEffector.enabled = false;
        }
    }
      
}
