using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticConstPlatform2 : MonoBehaviour
{
    private void Awake()
    { 
        ButtonTrigger.onButtonHit += DisableEffectors;
    }
    private void DisableEffectors()
    {
        Effector2D nForceEffector = transform.Find("NForce").GetComponent<Effector2D>();
        if (nForceEffector != null)
            nForceEffector.enabled = false;

        Effector2D sForceEffector = transform.Find("SForce").GetComponent<Effector2D>();
        if (sForceEffector != null)
            sForceEffector.enabled = false;
    }
      
}
