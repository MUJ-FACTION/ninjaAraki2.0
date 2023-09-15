using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public SpriteRenderer playerSprite;
    public float moveSpeed;
    public float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // returns 1, -1 or 0 based on "A" and "D" key inputs.
        float horzontalInput = Input.GetAxis("Horizontal");

        // returns 1, -1 or 0 based on "W" and "S" key inputs.
        float verticalInput = Input.GetAxis("Vertical");

        if(horzontalInput < -0.1f)
        {
            playerSprite.flipX = true;
        }
        else if(horzontalInput > 0.1f)
        {
            playerSprite.flipX = false;
        }

        Vector3 newPos = transform.position + new Vector3(horzontalInput * moveSpeed * Time.deltaTime, 0, 0);

        transform.position = newPos;
    }
}
