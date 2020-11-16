using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] protected CharacterManager characterManager;

    private void Start()
    {
        characterManager.onMove += PerformMovement;
    }

    protected void PerformMovement()
    {
        if(characterManager.canMove)
        {
            Vector2 dir = characterManager.direction;
            if(dir.magnitude > 1) dir = dir.normalized;
            Vector2 movementVector = dir * characterManager.speed * Time.fixedDeltaTime;
            characterManager.rb.MovePosition( characterManager.rb.position + movementVector);
        }
    }

}
