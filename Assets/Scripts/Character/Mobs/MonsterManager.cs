using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : CharacterManager
{
    [SerializeField] protected MonsterBaseMovementLogic monsterMovement;
    public Transform target;
    public float range;
    public float attackTimer;

    private void Start()
    {
        target = GameManager.Player.transform;
    }

    void Update()
    {
        direction = monsterMovement.CalculateDistanceWithTarget(transform.position, target.position);
    }

    private void FixedUpdate()
    {
        if(direction.magnitude > 1)
        {
            if (isMoving)
            {
                OnMove();
            }
            else
            {
                isMoving = true;
                StartMoving();
                OnMove();
            }
        }
        else
        {
            isMoving = false;
            StopMoving();
        }
    }
}
