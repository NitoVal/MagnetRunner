using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffectSwitch : MonoBehaviour
{
    
    void Awake()
    {
        PlayerMagnet.onSwitchedPolarity += ChangeParticleEffect;
    }

    private void ChangeParticleEffect()
    {
        throw new NotImplementedException();
    }
}
