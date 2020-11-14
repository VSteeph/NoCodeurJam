using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AvatarManager))]
public class AvatarDodge : MonoBehaviour
{
    private AvatarManager avatarManager;
    public bool Dodge;

    void Awake()
    {
        avatarManager = this.GetComponent<AvatarManager>();
    }
    void Update()
    {
        if(Input.GetButtonDown("Dodge") && !Dodge)
        {
            avatarManager.invFrames.SetInvFrames(0.5f);
            Dodge = true;
            avatarManager.movement.move = true;
            DodgeAction();
        }
    }

    public void DodgeAction()
    {
        avatarManager.rb.AddForce(avatarManager.movement.InputVector * 1.5f, ForceMode2D.Impulse);
    }
}
