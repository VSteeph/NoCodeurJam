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
                playerManager.rb.AddForce(playerManager.direction * playerManager.dodgeForce, ForceMode2D.Impulse);
            }
            else
            {
                playerManager.canMoveWithInput = true;
                playerManager.rb.velocity = Vector2.zero;
                playerManager.isDodging = false;
                playerManager.AfterDodge();
            }
        }
    }

    private void PerformDodge()
    {
        playerManager.invFrames.StartInvulnerabilityFrame(playerManager.dodgeDurationInFrames);
        playerManager.canMoveWithInput = false;
        dodgeTimer = 0;
        dodgeFrame = 0;
        StartCoroutine(StartDodgeCooldown());
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
