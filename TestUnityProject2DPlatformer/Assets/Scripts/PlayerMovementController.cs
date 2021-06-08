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
    public float checkGroundRadius; 
    public LayerMask groundLayer;

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
        if (Input.GetKeyDown(KeyCode.Space)) 
        { 
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); 
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
