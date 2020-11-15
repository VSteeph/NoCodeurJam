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
        characterManager.onShot+=PlayShoot;
        characterManager.onHit += PlayHit;
        Lookup();
    }


    void Lookup()
    {
        ShootEventDescription = RuntimeManager.GetEventDescription(ShootEvent);
        DodgeEventDescription = RuntimeManager.GetEventDescription(DodgeEvent);
        HitEventDescription = RuntimeManager.GetEventDescription(HitEvent);
        RobotIdleDescription = RuntimeManager.GetEventDescription(RobotIdle);
        RobotDeathDescription = RuntimeManager.GetEventDescription(Death);
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