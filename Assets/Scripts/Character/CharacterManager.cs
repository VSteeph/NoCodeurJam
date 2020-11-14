using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterManager : MonoBehaviour
{
    [Header("Refs")]
    public InvulnerabilityFrame invFrames;
    public Rigidbody2D rb;
    public Collider2D col;

    [Header("Stats")]
    public float speed = 10;
    public float Energy = 100;

    // Character State
    [HideInInspector] public bool isInvulnerable = false;
    [HideInInspector] public bool isMoving = false;
    [HideInInspector] public bool canMove = true;
    [HideInInspector] public bool canDodge = true;
    [HideInInspector] public bool canShot = true;

    // Event
    public event System.Action onHit;
    public event System.Action onSpawn;
    public event System.Action onDeath;

    //Movement
    [HideInInspector] public Vector2 direction { get; protected set; }
    public event System.Action startMoving;
    public event System.Action onMove;
    public event System.Action stopMoving;



    // Invulnerability Frame
    public event System.Action onInvulnerability;
    public event System.Action afterInvulnerability;

    //Shooting
    [Header("Shooting")]
    public float shotCooldown = 0.5f;
    public BaseBullet loadedBullet;
    public event System.Action onShot;
    public event System.Action afterShot;

    private void Awake()
    {
        Init();
    }

    protected virtual void Init()
    {
        canMove = true;
    }

    public void StartMoving()
    {
        startMoving?.Invoke();
    }

    public void OnMove()
    {
        onMove?.Invoke();
    }

    public void StopMoving()
    {
        stopMoving?.Invoke();
    }

    public void OnShot()
    {
        onShot?.Invoke();
    }

    public void AfterShot()
    {
        afterShot?.Invoke();
    }

    public virtual Vector3 GetAim()
    {
        return Vector3.zero;
    }
}
