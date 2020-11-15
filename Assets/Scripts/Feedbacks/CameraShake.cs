using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    public static CinemachineVirtualCamera cinemachine;
    public CinemachineVirtualCamera Source;
    private static float shakeTimer;

    void Awake()
    {
        cinemachine = Source;
    }

    public static void ShakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin CineBasicMultiPerlin = cinemachine.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        CineBasicMultiPerlin.m_AmplitudeGain = intensity;
        shakeTimer = time;
    }

    void Update()
    {
        if(shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if(shakeTimer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin CineBasicMultiPerlin = cinemachine.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                CineBasicMultiPerlin.m_AmplitudeGain = 0;
                cinemachine.enabled = false;
                cinemachine.transform.rotation = Quaternion.Euler(0, 0, 0);
                cinemachine.enabled = true;
            }
        }
    }

}
