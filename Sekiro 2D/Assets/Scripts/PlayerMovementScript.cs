using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    public float speed = 4f;
    private bool isFacingRight = true;
    private Vector2 direction;

    SpriteRenderer playerSpriteRenderer;
    Sprite playerRunningSprite;
    Sprite playerIDLESprite;
    RigidBody2D playerRigidBody;

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (horizontal != 0 || vertical != 0)
            playerSpriteRenderer.sprite = playerRunningSprite;
        else
            playerSpriteRenderer.sprite = playerIDLESprite;

        direction.x = horizontal;
        direction.y = vertical;
        direction = direction.normalized;

        Flip();
    }
    private void FixedUpdate()
    {
        playerRigidBody.MovePosition(playerRigidBody.position + direction * speed * Time.deltaTime);
    }
    void Flip()
    {
        if ((isFacingRight && horizontal < 0f) || (!isFacingRight && horizontal > 0f))
        {
            isFacingRight = !isFacingRight;
            transform.localScale = new Vector3 (transform.localScale.x * -1f, transform.localScale.y, transform.localScale.z);
        }
    }
}
