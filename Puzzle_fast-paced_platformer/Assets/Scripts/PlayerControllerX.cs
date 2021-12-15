using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] [Range(0, 1)] private float cutHeight;
    [SerializeField] private float groundCheckRadius;

    [Header("Timers")]
    [SerializeField] private float jumpBuffer = 0; //jump buffer - lépe responzivní jump
    [SerializeField] private float jumpBufferTime = 0.1f;
    [SerializeField] private float groundedRemember = 0; // coyote/hang time
    [SerializeField] private float groundedRememberTime = 0.2f;

    [Header("Ground Check variables")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Animator animator;

    private bool isFlippedRight;
    private bool isGrounded;

    private float horizontalX;
    private Rigidbody2D rb;

    private void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontalX = Input.GetAxisRaw("Horizontal");
        Jump();
    }
    private void FixedUpdate()
    {
        Movement();
        NormalizeSlope();
        //hit = Physics2D.Raycast(transform.position, -transform.up, 3);
        //rb.velocity = new Vector3(hit.normal.y, -hit.normal.x, 0);

    }

    void NormalizeSlope()
    {
        // Attempt vertical normalization
        if (isGrounded)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 5f, whatIsGround);

            if (hit.collider != null && Mathf.Abs(hit.normal.x) > 0.1f)
            {
                Debug.DrawRay(hit.point, hit.normal, Color.green);
                // Apply the opposite force against the slope force 
                // You will need to provide your own slopeFriction to stabalize movement
                rb.velocity = new Vector2(rb.velocity.x - (hit.normal.x * 0.5f), rb.velocity.y);

                //Move Player up or down to compensate for the slope below them
                Vector3 pos = transform.position;
                pos.y += -hit.normal.x * Mathf.Abs(rb.velocity.x) * Time.fixedDeltaTime * (rb.velocity.x - hit.normal.x > 0 ? 1 : -1);
                transform.position = pos;
            }
        }
    }
    //Player getting hit
    private void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        groundedRemember -= Time.deltaTime; // -0.1234

        if (isGrounded) //pokud na zemi
        {
            //èasovaný grounded => pokud vìtší nìž 0, mohu skákat, pokud menší, nemohu
            groundedRemember = groundedRememberTime; //0.2f
        }
        jumpBuffer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpBuffer = jumpBufferTime; // bude 0.1

        }
        if (Input.GetKeyUp(KeyCode.Space) && groundedRemember > 0)
        {
            
                if (rb.velocity.y > 0)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce * cutHeight);

                }
            
        }
        if (jumpBuffer > 0 && groundedRemember > 0) //pokud 0.2
        {
            jumpBuffer = 0;
            groundedRemember = 0;

            rb.velocity = new Vector2(rb.velocity.x, jumpForce); //skoè 
        }
    }
    private void Movement()
    {
        rb.velocity = new Vector2(horizontalX * movementSpeed, rb.velocity.y);
        // -1, 0, 1
        if (horizontalX < 0 && !isFlippedRight)
        {
            Flip();
        }
        if (horizontalX > 0 && isFlippedRight)
        {
            Flip();
        }
    }
    private void Flip()
    {
        isFlippedRight = !isFlippedRight;
        transform.Rotate(0f, 180f, 0f);
    }
}

