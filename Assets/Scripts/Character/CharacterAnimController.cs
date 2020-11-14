using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimController : MonoBehaviour
{
    [SerializeField] protected CharacterManager characterManager;
    [SerializeField] protected Animator animator;

    private void Start()
    {
        characterManager.startMoving += StartMoving;
        characterManager.stopMoving += StopMoving;
    }

    private void StartMoving()
    {
        animator.SetBool("Move", true);
    }

    private void StopMoving()
    {
        animator.SetBool("Move", false);
    }
}
