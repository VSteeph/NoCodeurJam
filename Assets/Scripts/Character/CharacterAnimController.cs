using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimController : MonoBehaviour
{
    [SerializeField] protected CharacterManager characterManager;
    [SerializeField] protected Animator animator;

    protected virtual void Init()
    {
        characterManager.startMoving += StartMoving;
        characterManager.stopMoving += StopMoving;
    }

    private void Start()
    {
        Init();
    }

    protected void StartMoving()
    {
        animator.SetBool("Move", true);
    }

    protected void StopMoving()
    {
        animator.SetBool("Move", false);
    }
}
