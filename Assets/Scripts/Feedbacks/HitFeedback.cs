using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFeedback : FeedbackManager
{
    [SerializeField] private int framesOnHit = 10;
    [SerializeField] protected Animator animator;
    [SerializeField] private SpriteRenderer weaponRenderer;
    private Sprite originalSprite;
    private int currentFrames;
    public bool UseCameraShake;


    private void Start()
    {
        characterManager.onHit += SwapSprite;
        if(UseCameraShake) characterManager.onHit += MediumSCreenShake;
    }

    private void SwapSprite()
    {
        currentFrames = 0;
        animator.SetBool("isHit", true);
        StartCoroutine(SwitchingSprite());
    }

    private void MediumSCreenShake()
    {
        CameraShake.ShakeCamera(10, 0.5f);
    }

    private IEnumerator SwitchingSprite()
    {
        while (currentFrames < framesOnHit)
        {
            currentFrames++;
            if (currentFrames == framesOnHit)
            {
                animator.SetBool("isHit", false);
            }
            yield return null;
        }
    }
}
