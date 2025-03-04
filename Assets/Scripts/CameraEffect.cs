using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraEffects : MonoBehaviour
{
    public static CameraEffects Singleton;

    private float intensity;
    private bool isShaking = false;
    private Vector3 positionInitial;
    private float timer = 0;
    public static CinemachineVirtualCamera vc;
    CinemachineBasicMultiChannelPerlin mcp;
    private void Awake()
    {
        if (Singleton == null)
            Singleton = this;
        else
            Destroy(this);

        vc = GetComponent<CinemachineVirtualCamera>();
        if (vc != null)
        {
            mcp = vc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            mcp.m_AmplitudeGain = 0f;
        }
    }

    private void Update()
    {
        if (!isShaking) return;

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            isShaking = false;
            timer = 0;
            mcp.m_AmplitudeGain = 0f;
        }

        transform.position = positionInitial + (Random.insideUnitSphere * intensity);
    }
    public void ShakeCamera(float duration, float intensity)
    {
        mcp.m_AmplitudeGain = intensity;

        timer = duration;
        isShaking = true;
    }

}