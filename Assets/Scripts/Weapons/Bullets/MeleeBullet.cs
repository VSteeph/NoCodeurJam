using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeBullet : BaseBullet
{
    public override Vector2 GetBulletDistanceTraveled(Vector3 direction)
    {
        return Vector2.zero;
    }

    public override void Impact(Animator anim = null)
    {
        Debug.Log("Impact Effect");
    }
}
