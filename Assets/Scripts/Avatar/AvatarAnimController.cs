﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarAnimController : MonoBehaviour
{
    [SerializeField] private AvatarManager avatarManager;
    [SerializeField] Animator animator;
    void Update()
    {
        if(avatarManager.dodge.Dodge)
        {
            animator.SetBool("Dodge", true);
        }
        else if(avatarManager.movement.InputVector.magnitude > 0 && !avatarManager.dodge.Dodge)
        {
            animator.SetBool("Move", true);
            animator.SetBool("Dodge", false);
        }
        else
        {
            animator.SetBool("Move", false);
            animator.SetBool("Dodge", false);
        }
    }
}
