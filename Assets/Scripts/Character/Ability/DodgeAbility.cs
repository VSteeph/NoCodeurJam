using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeAbility : MonoBehaviour
{
    [SerializeField] private PlayerManager playerManager;
    private float dodgeTimer = 0;
    private int dodgeFrame = 0;

    void Start()
    {
        playerManager = this.GetComponent<PlayerManager>();
        playerManager.onDodge += PerformDodge;
    }

    private void FixedUpdate()
    {
        if (playerManager.isDodging)
        {
            if (dodgeFrame < playerManager.dodgeDurationInFrames)
            {
                dodgeFrame++;
            }
            else
            {
                playerManager.canMoveWithInput = true;
                playerManager.canMove = true;
                playerManager.rb.velocity = Vector2.zero;
                playerManager.isDodging = false;
                playerManager.AfterDodge();
            }
        }
    }

    private void PerformDodge()
    {
        playerManager.invFrames.StartInvulnerabilityFrame(playerManager.dodgeDurationInFrames);
        CameraShake.ShakeCamera(2, 0.1f);
        playerManager.canMoveWithInput = false;
        playerManager.canMove = false;
        dodgeTimer = 0;
        dodgeFrame = 0;
        StartCoroutine(StartDodgeCooldown());
        playerManager.rb.AddForce(playerManager.direction * playerManager.dodgeForce, ForceMode2D.Impulse);
        playerManager.isDodging = true;
    }

    private IEnumerator StartDodgeCooldown()
    {
        while (dodgeTimer < playerManager.dodgeCooldown)
        {
            dodgeTimer += Time.deltaTime;
            yield return null;
        }
        if (dodgeTimer > playerManager.dodgeCooldown)
        {
            Debug.Log("Can Dodge again");
            playerManager.canDodge = true;
        }
    }
}
