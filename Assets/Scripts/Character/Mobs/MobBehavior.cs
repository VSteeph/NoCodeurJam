using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MobBehavior : MonoBehaviour
{
    public enum EnemyType {GetClose, Shooter}
    [Header("Stats")]
    public EnemyType type;
    public float speed;
    public float ShootRange;
    [Header("Refs")]
    public Rigidbody2D rb;

    void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
