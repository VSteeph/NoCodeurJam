using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : CharacterManager
{
    [SerializeField] protected MonsterBaseMovementLogic monsterMovement;
    public Transform target;
    public CharacterManager playerManager;
    public int range;
    public float attackTimer;

    private void Start()
    {
        target = GameManager.Player.transform;
        onShot += BlockMovement;
        afterShot += AllowMovement;
        loadedBullet.range = range;
    }

    void Update()
    {
        direction = monsterMovement.CalculateDistanceWithTarget(transform.position, target.position);
    }

    private void FixedUpdate()
    {
        if (direction.magnitude > range)
        {
            if (!isMoving)
            {
                isMoving = true;
                StartMoving();
            }
            OnMove();

        }
        else
        {
            Debug.Log(gameObject + " is attacking");
            isMoving = false;
            OnShot();
        }
    }

    private void BlockMovement()
    {
        canMove = false;
    }
    private void AllowMovement()
    {
        canMove = true;
    }
}
