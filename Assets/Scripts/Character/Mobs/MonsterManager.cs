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
    public float rangeDetection;

    [Header("Refs")]
    public RobotManager robotManager;
    [HideInInspector] public Transform target;
    [HideInInspector] public CharacterManager playerManager;

    private void Start()
    {
        onShot += BlockMovement;
        afterShot += AllowMovement;
        loadedBullet.range = range;
        target = GameManager.Player.transform;
        canMove = true;
    }

    void Update()
    {
        direction = monsterMovement.CalculateDistanceWithTarget(transform.position, target.position);
    }

    private void FixedUpdate()
    {
        if(direction.magnitude < rangeDetection)
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
                isMoving = false;
                OnShot();
            }
        }
        else
        {
            isMoving = false;
            StopMoving();
        }
    }

    public override void OnDeath()
    {
        base.OnDeath();
        RemoveSelf();
        CameraShake.ShakeCamera(4, 0.1f);
        Destroy(gameObject);
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

    public void RemoveSelf()
    {
        robotManager.Monsters.Remove(this);
    }

    public override void OnHit(int damage, Vector3? explosionPoint = null)
    {
        base.OnHit(damage, explosionPoint);

    }
}
