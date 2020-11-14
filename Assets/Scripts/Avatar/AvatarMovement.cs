using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AvatarManager))]
public class AvatarMovement : MonoBehaviour
{
    public Vector2 InputVector;
    public bool move;
    private AvatarManager avatarManager;

    private void Awake()
    {
        avatarManager = this.GetComponent<AvatarManager>();
        avatarManager.rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(!move)
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            InputVector = new Vector2(x, y);
            if(InputVector.magnitude > 1) InputVector.Normalize();
        }
    }

    private void FixedUpdate()
    {
        Vector2 movementVector = InputVector * avatarManager.speed * Time.fixedDeltaTime;
        avatarManager.rb.MovePosition(new Vector2(this.transform.position.x, this.transform.position.y) + movementVector);
    }
}
