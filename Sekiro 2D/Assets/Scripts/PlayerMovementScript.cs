using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    private float speed = 4f;
    private bool isFacingRight = true;

    [SerializeField] SpriteRenderer playerSpriteRenderer;
    [SerializeField] Sprite playerRunningSprite;
    [SerializeField] Sprite playerIDLESprite;

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (horizontal != 0 || vertical != 0)
            playerSpriteRenderer.sprite = playerRunningSprite;
        else
            playerSpriteRenderer.sprite = playerIDLESprite;

        Flip();
    }
    private void FixedUpdate()
    {
            transform.position = new Vector3(transform.position.x + horizontal * speed * Time.deltaTime, transform.position.y + vertical * speed * Time.deltaTime, 0f);
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
