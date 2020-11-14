using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AvatarManager))]
public class AvatarMovement : MonoBehaviour
{
    public Vector2 InputVector { get; private set; }
    public bool move;
    private AvatarManager avatarManager;

    private void Start()
    {
        avatarManager = this.GetComponent<AvatarManager>();
        avatarManager.rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (avatarManager.canMoveWithInput)
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            InputVector = new Vector2(x, y);
        }
    }

    private void FixedUpdate()
    {
        if (avatarManager.canMove)
        {
            Vector2 movementVector = InputVector * avatarManager.speed * Time.fixedDeltaTime;
            avatarManager.rb.MovePosition(new Vector2(this.transform.position.x, this.transform.position.y) + movementVector);
        }
    }
}
