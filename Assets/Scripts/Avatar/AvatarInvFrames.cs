using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AvatarManager))]
public class AvatarInvFrames : MonoBehaviour
{
    [Header("Refs")]
    [SerializeField] BoxCollider2D col;
    [SerializeField] bool invincible;
    private AvatarManager avatarManager;

    void Awake()
    {
        avatarManager = this.GetComponent<AvatarManager>();
    }
    public void SetInvFrames(float time)
    {
        StopAllCoroutines();
        invincible = true;
        col.enabled = false;
        StartCoroutine(WaitToGiveBack(time));
    }

    IEnumerator WaitToGiveBack(float time)
    {
        yield return new WaitForSeconds(time);
        invincible = false;
        col.enabled = true;
        if(avatarManager.movement.move) {
            avatarManager.movement.move = false;
            avatarManager.dodge.Dodge = false;
        }
    }
}
