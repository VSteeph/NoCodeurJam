using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : CharacterManager
{
    // Character State
    [HideInInspector] public bool canMoveWithInput = true;
    [HideInInspector] public bool isDodging = false;

    [SerializeField] public int invulnerabilityFramesAfterHit = 50;

    //Dodge
    [Header("Dodge")]
    public float dodgeCooldown = 2f;
    public int dodgeDurationInFrames = 4;
    public float dodgeForce = 1.5f;
    public event System.Action onDodge;
    public event System.Action afterdodge;

    //Aim
    public Vector3 mousePosition;

    //respawn
    private Vector3 initialPosition;

    private void Awake()
    {
        base.Init();
        canMoveWithInput = true;
        initialPosition = transform.position;
    }

    private void Start()
    {
        onDeath += Reset;
    }
    private void Update()
    {
        GetInput();
    }

    private void FixedUpdate()
    {
        if (direction.magnitude > 0 && !isDodging)
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
            StopMoving();
        }
    }

    void GetInput()
    {
        if (canMoveWithInput)
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            direction = new Vector2(x, y);
        }

        if (Input.GetButtonDown("Dodge") && canDodge)
        {
            canDodge = false;
            onDodge?.Invoke();
        }

        if (Input.GetMouseButtonDown(0))
        {
            OnShot();
        }

    }

    public void AfterDodge()
    {
        afterdodge?.Invoke();
    }

    public override Vector3 GetAim()
    {
        return mousePosition;
    }

    public override void OnHit(int damage, Vector3? explosionPoint = null)
    {
        if(!isInvulnerable)
        {
            invFrames.StartInvulnerabilityFrame(invulnerabilityFramesAfterHit);
            base.OnHit(damage, explosionPoint);
        }
        else
        {
            Debug.Log("he is invulnerable");
        }
    }

    public void Reset()
    {
        transform.position = initialPosition;
        rb.velocity = new Vector2(0, 0);
        Init();
    }
}
