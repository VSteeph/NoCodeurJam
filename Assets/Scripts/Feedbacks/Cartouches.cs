using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cartouches : MonoBehaviour
{
    [Header("Refs")]
    [SerializeField] private Rigidbody2D rb;
    public Vector2 AimDir;

    void Start()
    {
        rb.AddForce(new Vector2(-AimDir.x, Mathf.Abs(AimDir.y)+1).normalized * 5, ForceMode2D.Impulse);
        Invoke("StopRigidbody", 1);
    }

    void StopRigidbody()
    {
        rb.isKinematic = true;
        rb.gravityScale = 0;
        rb.velocity = Vector2.zero;
        Invoke("TimeToDie", 1);
    }

    void TimeToDie()
    {
        Destroy(this.gameObject);
    }
}
