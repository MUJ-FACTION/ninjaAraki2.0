using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public SpriteRenderer playerSprite;
    public float moveSpeed;
    public float jumpForce;
    public float maxSpeedVertical;

    private float horizontalInput;
    private float verticalInput;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // returns 1, -1 or 0 based on key inputs.
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        HandleHorizontalSpriteFlip();
    }

    private void HandleHorizontalSpriteFlip()
    {
        if (horizontalInput < -0.1f)
        {
            // player is facing right
            playerSprite.flipX = true;
        }
        else if (horizontalInput > 0.1f)
        {
            // player is facing left
            playerSprite.flipX = false;
        }

    }

    private void FixedUpdate()
    {
        float currentSpeed = horizontalInput * moveSpeed * Time.deltaTime;

        // clamping the speed into a range to keep speed in control
        float clampedSpeed = Mathf.Clamp(currentSpeed, -maxSpeedVertical, maxSpeedVertical);
        Vector2 velocity = new Vector2(clampedSpeed, rb2d.velocity.y);

        // giving velocity (force) to the rigid body
        rb2d.velocity = velocity;
    }
}
