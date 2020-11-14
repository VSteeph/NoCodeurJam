using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RegularBullet : BaseBullet
{
    public override Vector2 GetBulletDistanceTraveled(Vector3 direction)
    {
        return (new Vector2(direction.x, direction.y) * bulletSpeed * Time.fixedDeltaTime);
    }

    public override void Impact()
    {
        Debug.Log("Impact Effect");
    }
}
