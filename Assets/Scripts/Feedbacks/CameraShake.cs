using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static Cinemachine.CinemachineImpulseSource ImpulseSource;
    public Cinemachine.CinemachineImpulseSource Source;

    void Awake()
    {
        ImpulseSource = Source;
    }

}
