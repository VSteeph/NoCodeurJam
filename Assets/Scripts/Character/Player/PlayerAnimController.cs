using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : CharacterAnimController
{
    [SerializeField] protected PlayerManager playerManager;


    void Start()
    {
        base.Init(); 
        playerManager.onDodge += StartDodging;
        playerManager.afterdodge += StopDodging;
    }

    private void StartDodging()
    {
        animator.SetBool("Dodge", true);
    }

    private void StopDodging()
    {
        animator.SetBool("Dodge", false);
    }
}
