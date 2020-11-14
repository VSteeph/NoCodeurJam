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
    public string senderTag;

    private float lifeDuration = 0f;

    public void InitializeProjectile(BaseBullet loadedBullet, string tag, Vector3 bulletDirection)
    {
        bullet = loadedBullet;
        rb = GetComponent<Rigidbody2D>();
        visualBullet = GetComponent<SpriteRenderer>();
        visualBullet.sprite = bullet.GetSprite();
        direction = Vector3.Normalize(bulletDirection - transform.position);
        senderTag = tag;
        isReady = true;
    }

    private void Update()
    {
        lifeDuration += Time.deltaTime;
        if (!bullet.isAlive(lifeDuration))
            Destroy(gameObject);
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
        if (senderTag == collision.tag)
            return;
        else
        {
            var collisionManager = collision.GetComponent<CharacterManager>();
            if (collisionManager != null)
            {
                collisionManager.OnHit(bullet.damage, transform.position);
            }
            bullet.Impact();
            Destroy(gameObject);
        }

    }
}
