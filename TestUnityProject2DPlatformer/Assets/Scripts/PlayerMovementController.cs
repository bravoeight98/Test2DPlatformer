using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    Rigidbody2D rb; 

    public float speed = 4.0f;

    public float jumpForce = 5.0f;

    bool isGrounded = false; 
    public Transform isGroundedChecker; 
    public float checkGroundRadius = 0.5f; 
    public LayerMask groundLayer;

    public float fallMultiplier = 2.5f; 
    public float lowJumpMultiplier = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        BetterJump();
        CheckIfGrounded();
    }

    //Move the Player Hrizontally
    void Move() 
    { 
        float x = Input.GetAxisRaw("Horizontal"); 
        float moveBy = x * speed; 
        rb.velocity = new Vector2(moveBy, rb.velocity.y); 
    }

    //Make Player Jump
    void Jump() 
    { 
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) 
        { 
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); 
        } 
    }

    //Make Player Jump Like Mario (Inspired By https://www.youtube.com/watch?v=7KiK0Aqtmzc&ab_channel=BoardToBitsGames)
    void BetterJump() 
    {
        if (rb.velocity.y < 0) 
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        } 
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space)) 
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }   
}

    //Check of the player is touching the ground
    void CheckIfGrounded() 
    { 
        Collider2D collider = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer); 

        if (collider != null) 
        { 
            isGrounded = true; 
        } 
        else 
        { 
            isGrounded = false; 
        } 
    }
}
