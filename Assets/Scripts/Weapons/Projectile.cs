using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent((typeof(Rigidbody2D)), (typeof(SpriteRenderer)))]
public class Projectile : MonoBehaviour
{
    public BaseBullet bullet;
    [HideInInspector] public Vector3 direction;
    private SpriteRenderer visualBullet;
    private Rigidbody2D rb;
    private bool isReady = false;

    public void InitializeProjectile(BaseBullet loadedBullet, Vector3 bulletDirection)
    {
        bullet = loadedBullet;
        rb = GetComponent<Rigidbody2D>();
        visualBullet = GetComponent<SpriteRenderer>();
        visualBullet.sprite = bullet.GetSprite();
        direction = Vector3.Normalize(bulletDirection - transform.position);
        isReady = true;
    }

    private void FixedUpdate()
    {
        if (isReady)
        {
            var newPostion = bullet.GetBulletDistanceTraveled(direction);
            rb.MovePosition(rb.position + newPostion);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bullet.Impact();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bullet.Impact();
    }




}
