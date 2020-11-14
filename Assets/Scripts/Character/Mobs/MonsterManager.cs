using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : CharacterManager
{
    [Header("Monster Movement IA")]
    [SerializeField] protected MonsterBaseMovementLogic monsterMovement;

    [Header("Attack stats")]
    public int range;
    public float attackTimer;

    [HideInInspector] public Transform target;
    [HideInInspector] public CharacterManager playerManager;

    private void Start()
    {
        onShot += BlockMovement;
        afterShot += AllowMovement;
        loadedBullet.range = range;
        canMove = true;
    }

    void Update()
    {
        direction = monsterMovement.CalculateDistanceWithTarget(transform.position, target.position);
    }

    private void FixedUpdate()
    {
        Debug.Log(direction.magnitude);
        if (direction.magnitude > range)
        {
            Debug.Log("Moving");
            if (!isMoving)
            {
                isMoving = true;
                StartMoving();
            }
            OnMove();
        }
        else
        {
            Debug.Log("Attacking");
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

    public override Vector3 GetAim()
    {
        return target.position;
    }
}
