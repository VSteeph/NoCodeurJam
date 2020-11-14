using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cartouches : MonoBehaviour
{
    [Header("Refs")]
    [SerializeField] private Rigidbody2D rb;
    public Vector2 AimDir;
    public float force;

    void Start()
    {
        rb.AddForce(new Vector2(-AimDir.x, Mathf.Abs(AimDir.y)+1).normalized * force, ForceMode2D.Impulse);
        rb.AddTorque(Random.value * force * 200);
        Invoke("StopRigidbody", 1);
    }

    void StopRigidbody()
    {
        rb.isKinematic = true;
        rb.gravityScale = 0;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        Invoke("TimeToDie", 1);
    }

    void TimeToDie()
    {
        Destroy(this.gameObject);
    }
}
