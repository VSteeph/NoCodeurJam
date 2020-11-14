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

    void Awake()
    {
        if(GameManager.avatarManager) Destroy(this.gameObject);
        else GameManager.avatarManager = this;
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }
}
