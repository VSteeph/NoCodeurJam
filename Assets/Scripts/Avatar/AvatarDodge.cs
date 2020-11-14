using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AvatarManager))]
public class AvatarDodge : MonoBehaviour
{
    private AvatarManager avatarManager;
    private float dodgeTimer = 0;
    private int dodgeFrame = 0;


    void Start()
    {
        avatarManager = this.GetComponent<AvatarManager>();
        avatarManager.onDodge += PerformDodge;
    }

    private void FixedUpdate()
    {
        if (avatarManager.isDodging)
        {
            if (dodgeFrame < avatarManager.dodgeDurationInFrames)
            {
                dodgeFrame++;
                avatarManager.rb.AddForce(avatarManager.movement.InputVector * 1.5f, ForceMode2D.Impulse);
            }
            else
            {
                avatarManager.canMoveWithInput = true;
                avatarManager.isDodging = false;
                avatarManager.AfterDodge();
                Debug.Log("End of dodging with " + avatarManager.movement.InputVector);
            }
        }
    }

    private void PerformDodge()
    {
        avatarManager.invFrames.StartInvulnerabilityFrame(avatarManager.dodgeDurationInFrames);
        avatarManager.canMoveWithInput = false;
        dodgeTimer = 0;
        dodgeFrame = 0;
        StartCoroutine(StartDodgeCooldown());
        avatarManager.isDodging = true;
        Debug.Log("is dodging with " + avatarManager.movement.InputVector);
    }

    private IEnumerator StartDodgeCooldown()
    {
        while (dodgeTimer < avatarManager.dodgeCooldown)
        {
            dodgeTimer += Time.deltaTime;
            yield return null;
        }
        if (dodgeTimer > avatarManager.dodgeCooldown)
        {
            Debug.Log("Can Dodge again");
            avatarManager.canDodge = true;
        }
    }

}
