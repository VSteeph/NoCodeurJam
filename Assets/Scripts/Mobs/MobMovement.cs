using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MobBehavior))]
public class MobMovement : MonoBehaviour
{
    private Transform avatar;
    private MobBehavior behavior;
    private Vector3 dirVector;
    private bool move;

    void Start()
    {
        avatar = GameManager.avatarManager.transform;
        behavior = this.GetComponent<MobBehavior>();
    }

    void Update()
    {
        dirVector = (avatar.position - this.transform.position);
    }

    void FixedUpdate()
    {
        if(behavior.type == MobBehavior.EnemyType.GetClose)
        {
            behavior.rb.MovePosition(this.transform.position + (dirVector.normalized * Time.fixedDeltaTime * behavior.speed));
        }
        else if(behavior.type == MobBehavior.EnemyType.Shooter)
        {
            if(Vector3.Distance(this.transform.position, avatar.position) <= behavior.ShootRange ) 
            {
                move = true;
                //shoot
            }
            else if (Vector3.Distance(this.transform.position, avatar.position) > behavior.ShootRange && !move) behavior.rb.MovePosition(this.transform.position + (dirVector.normalized * Time.fixedDeltaTime * behavior.speed));
        }
    }
}
