using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffectSwitch : MonoBehaviour
{
    public ParticleSystem plusVFX;
    public ParticleSystem minusVFX;
    void Awake()
    {
        PlayerMagnet.onSwitchedPolarity += ChangeParticleEffect;
    }

    private void ChangeParticleEffect(string layer)
    {
        if (layer == "N")
        {
            plusVFX.Play();
            minusVFX.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
        if (layer == "S")
        {
            minusVFX.Play();
            plusVFX.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
    }
}
