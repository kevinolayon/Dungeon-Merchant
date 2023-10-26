using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed; // Control the movement speed
    public Rigidbody2D rb;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
    }

    public void Movement()
    {
        // Input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Movement vector calculation
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized * moveSpeed;

        // Apply the movement to the Rigidbody2D
        rb.velocity = movement;

        // Set animation parameters
        anim.SetFloat("horizontal", movement.x);
        anim.SetFloat("vertical", movement.y);
        anim.SetFloat("speed", movement.sqrMagnitude);
    }
}
