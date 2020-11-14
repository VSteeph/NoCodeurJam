using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AvatarManager))]
public class AvatarInvFrames : MonoBehaviour
{
    [Header("Refs")]
    [SerializeField] BoxCollider2D col;
    private AvatarManager avatarManager;
    private int invulnerableFrameCount;
    private int currentFrame;

    void Awake()
    {
        avatarManager = this.GetComponent<AvatarManager>();
    }

    private void FixedUpdate()
    {
        if (avatarManager.isInvulnerable)
        {
            if (currentFrame < invulnerableFrameCount)
            {
                currentFrame++;
            }
            else
            {
                StopInvulnerability();
            }
        }
    }

    public void StartInvulnerabilityFrame(int nbFrames)
    {
        Debug.Log("Invulnerable");
        avatarManager.isInvulnerable = true;
        invulnerableFrameCount = nbFrames;
        currentFrame = 0;
        col.enabled = false;
    }

    private void StopInvulnerability()
    {
        Debug.Log("No longer Invulnerable");
        avatarManager.isInvulnerable = false;
        col.enabled = true;
    }
}
