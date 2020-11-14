using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBullet : MonoBehaviour
{
    [SerializeField] protected Sprite visual;
    [SerializeField] protected float bulletSpeed;

    public virtual Sprite GetSprite()
    {
        return visual;
    }

    public abstract Vector2 GetBulletDistanceTraveled(Vector3 direction);

    public abstract void Impact();

}
