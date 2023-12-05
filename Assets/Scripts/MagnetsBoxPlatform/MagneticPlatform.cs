using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticPlatform : MonoBehaviour
{
    private void Awake()
    { 
        ButtonTrigger.onButtonHit += DisableEffectors;
    }
    private void DisableEffectors()
    {
        GameObject nForceEffector = transform.Find("GzoneN").gameObject;
        if (nForceEffector != null)
            nForceEffector.SetActive(false);

        GameObject sForceEffector = transform.Find("GzoneS").gameObject;
        if (sForceEffector != null)
            sForceEffector.SetActive(false);
    }
      
}
