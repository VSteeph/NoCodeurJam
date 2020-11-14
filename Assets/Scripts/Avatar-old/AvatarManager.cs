using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AvatarManager : MonoBehaviour
{
    [Header("Stats")]
    public float speed;
    public float Energy = 100;
    [Header("Refs")]
    public AvatarInvFrames invFrames;
    public AvatarMovement movement;
    public AvatarDodge dodge;
    public Rigidbody2D rb;

    // Avatar State
    [HideInInspector] public bool isInvulnerable = false;
    [HideInInspector] public bool canMoveWithInput = true;
    [HideInInspector] public bool canMove = true;
    [HideInInspector] public bool canDodge = true;
    [HideInInspector] public bool isDodging = false;
    [HideInInspector] public bool canShot = true;

    // Invulnerability Frame
    public event System.Action onInvulnerability;
    public event System.Action afterInvulnerability;

    // Aiming
    public Vector3 mousePosition;

    //Dodge
    [Header("Dodge")]
    public float dodgeCooldown = 2f;
    public int dodgeDurationInFrames = 4;
    public event System.Action onDodge;
    public event System.Action afterdodge;

    //Shooting
    [Header("Shooting")]
    public float shotCooldown = 0.5f;
    public IBullet loadedBullet;
    public event System.Action onShot;
    public event System.Action afterShot;


    void Awake()
    {
        if (GameManager.avatarManager) Destroy(this.gameObject);
        else GameManager.avatarManager = this;
        rb = this.GetComponent<Rigidbody2D>();
        canMove = true;
        canMoveWithInput = true;
    }

    private void Update()
    {
        GetInput();
    }

    void GetInput()
    {
        if (Input.GetButtonDown("Dodge") && canDodge)
        {
            canDodge = false;
            onDodge?.Invoke();
        }

        if (Input.GetMouseButtonDown(0) && canShot)
        {
            onShot?.Invoke();
        }

    }


    public void AfterDodge()
    {
        afterdodge?.Invoke();
    }

    public void AfterShot()
    {
        afterShot?.Invoke();
    }
}
