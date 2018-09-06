using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {
    public bool jump = false;               // Condition for whether the player should jump.

    public float speed = 150f;          // Amount of force added to move the player left and right.
    public float maxSpeed = 5f;             // The fastest the player can travel in the x axis.

    public float jumpForce = 50f;         // Amount of force added when the player jumps.
    public int extraJumps;
    private int jumpCount = 0;
    public float fallMultiplier = 2.5f;

    public string jumpButton = "Jump_P1";
    public string horizontalCrtl = "Horizontal_P1";


    public Transform groundCheck;          // A position marking where to check if the player is grounded.
    private bool grounded = false;          // Whether or not the player is grounded.
    public float checkRadius;
    public LayerMask whatIsGround;

    private Rigidbody rb;

    void Awake()
    {
        // Setting up references.
        groundCheck = transform.Find("groundCheck");
        rb = GetComponent<Rigidbody>();
        jumpCount = extraJumps;
    }

    void Update()
    {
        if (Input.GetButtonDown(jumpButton) && extraJumps > 0)
        {
            rb.AddForce(new Vector3(0f, jumpForce));
            jumpCount--;
        }else if(Input.GetButtonDown(jumpButton) && grounded) {
            rb.AddForce(new Vector3(0f, jumpForce));
            extraJumps = jumpCount;
        }
    }

    void FixedUpdate()
    {
        // Get array 
        Collider[] hitColliders = Physics.OverlapSphere(groundCheck.position,checkRadius,whatIsGround);
        // Check if ground is in array

        grounded = (hitColliders.Length != 0);
        
        // Cache the horizontal input.
        float h = Input.GetAxis(horizontalCrtl);
        
        // If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
        if (h * rb.velocity.x < maxSpeed)
            // ... add a force to the player.
            rb.AddForce(Vector3.right * h * speed);

        // If the player's horizontal velocity is greater than the maxSpeed...
        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
            // ... set the player's velocity to the maxSpeed in the x axis.
            rb.velocity = new Vector3(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);

        // Better jumping gravity simulation
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }
}
