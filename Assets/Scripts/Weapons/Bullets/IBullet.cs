using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBullet
{
    void Init(Vector3 initialAim, SpriteRenderer visualBullet, Rigidbody2D rigidBody);
    void Travel();
    void Impact();
}
