using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;


public class SoundManager : MonoBehaviour
{
    [Header("AvatarSounds")]
    [EventRef]
    public string ShootEvent = "";
    private  FMOD.Studio.EventDescription ShootEventDescription;
    [EventRef]
    public string DodgeEvent = "";
    private  FMOD.Studio.EventDescription DodgeEventDescription;
    [EventRef]
    public string HitEvent = "";
    private  FMOD.Studio.EventDescription HitEventDescription;
    [Header("RobotSounds")]
    [EventRef]
    public string RobotIdle = "";
    private  FMOD.Studio.EventDescription RobotIdleDescription;
    [EventRef]
    public string RobotHit = "";
    private  FMOD.Studio.EventDescription RobotHitDescription;
    [EventRef]
    public string RobotDeath = "";
    private  FMOD.Studio.EventDescription RobotDeathDescription;

    void Start() 
    {
        Lookup();
    }


    void Lookup()
    {
        ShootEventDescription = RuntimeManager.GetEventDescription(ShootEvent);
        DodgeEventDescription = RuntimeManager.GetEventDescription(DodgeEvent);
        HitEventDescription = RuntimeManager.GetEventDescription(HitEvent);
        RobotIdleDescription = RuntimeManager.GetEventDescription(RobotIdle);
        RobotHitDescription = RuntimeManager.GetEventDescription(RobotHit);
        RobotDeathDescription = RuntimeManager.GetEventDescription(RobotDeath);
    }

    public void PlayShoot()
    {
        RuntimeManager.PlayOneShot(ShootEvent);
    }

    public void PlayDodge()
    {
        RuntimeManager.PlayOneShot(DodgeEvent);
    }

    public void PlayHit()
    {
        RuntimeManager.PlayOneShot(HitEvent);
    }

    public void PlayRobotHit()
    {
        RuntimeManager.PlayOneShot(RobotHit);
    }

    public void PlayRobotDeath()
    {
        RuntimeManager.PlayOneShot(RobotDeath);
    }
}
