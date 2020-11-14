using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBullet : MonoBehaviour
{
    [SerializeField] protected Sprite visual;
    [SerializeField] protected float speed;
    [SerializeField] public int damage;
    [SerializeField] public int range;
    [SerializeField] protected float lifeDuration;

    public virtual Sprite GetSprite()
    {
        return visual;
    }

    public virtual bool isAlive(float currentLifeSpan)
    {
        if(lifeDuration > currentLifeSpan)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public abstract Vector2 GetBulletDistanceTraveled(Vector3 direction);

    public abstract void Impact();

}
