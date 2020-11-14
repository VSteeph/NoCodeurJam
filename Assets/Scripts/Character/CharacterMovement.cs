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
            Vector2 movementVector = characterManager.direction * characterManager.speed * Time.fixedDeltaTime;
            characterManager.rb.MovePosition(new Vector2(this.transform.position.x, this.transform.position.y) + movementVector);
        }
    }

}
