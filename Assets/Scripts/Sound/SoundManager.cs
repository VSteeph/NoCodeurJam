using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;


public class SoundManager : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] CharacterManager characterManager;
    [EventRef]
    public string ShootEvent = "";
    private  FMOD.Studio.EventDescription ShootEventDescription;
    [EventRef]
    public string DodgeEvent = "";
    private  FMOD.Studio.EventDescription DodgeEventDescription;
    [EventRef]
    public string HitEvent = "";
    private  FMOD.Studio.EventDescription HitEventDescription;
    [EventRef]
    public string RobotIdle = "";
    private  FMOD.Studio.EventDescription RobotIdleDescription;
    [EventRef]
    public string Death = "";
    private  FMOD.Studio.EventDescription RobotDeathDescription;

    void Start() 
    {
        if(characterManager != null)
        {
            characterManager.onShot += PlayShoot;
            characterManager.onHit += PlayHit;
        }
        Lookup();
    }


    void Lookup()
    {
        if(ShootEvent != "") ShootEventDescription = RuntimeManager.GetEventDescription(ShootEvent);
        if(DodgeEvent != "") DodgeEventDescription = RuntimeManager.GetEventDescription(DodgeEvent);
        if(HitEvent != "") HitEventDescription = RuntimeManager.GetEventDescription(HitEvent);
        if(RobotIdle != "") RobotIdleDescription = RuntimeManager.GetEventDescription(RobotIdle);
        if(Death != "") RobotDeathDescription = RuntimeManager.GetEventDescription(Death);
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

    public void PlayDeath()
    {
        RuntimeManager.PlayOneShot(Death);
    }
}