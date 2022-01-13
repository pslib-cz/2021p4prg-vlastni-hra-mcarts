using Assets.Scripts.Models;
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
    private bool isMoving;
    private float horizontalX;
    private Rigidbody2D rb;
    [SerializeField] GameObject PickUp;

    private QuestionController qc;
    private GameManager _gameManager;
    private PlayerActions inRange = PlayerActions.None;
    private BoxCollider2D bc;

    



    private void Start()
    {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        qc = GameObject.Find("Canvas").GetComponent<QuestionController>();
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        
    }

    private void Update()
    {
        if (inRange == PlayerActions.PickUp)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                qc.SeeQuestion(PickUp.GetComponent<Collider2D>(), PickUp);
            }
        }
        if (!_gameManager.isOver)
        {
            horizontalX = Input.GetAxisRaw("Horizontal");
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _gameManager.PauseGame();
            
        }
        

    }
    private void FixedUpdate()
    {
        if (!_gameManager.isOver)
        {
            Movement();
            NormalizeSlope();
            //hit = Physics2D.Raycast(transform.position, -transform.up, 3);
            //rb.velocity = new Vector3(hit.normal.y, -hit.normal.x, 0);
        }
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
    //pøesune se do jiného scriptu


    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider.gameObject.name);
        Time.timeScale = 1;
        Debug.Log("Ahoj");
        switch (collider.gameObject.tag)
        {
            case "PickUp":
                PickUp = collider.gameObject;
                if(PickUp.GetComponent<Animator>().GetBool("IsTriggered") == false)
                {
                    inRange = PlayerActions.PickUp;

                }
                else
                {
                    inRange = PlayerActions.None;
                }
                
                break;
            //case "PickDown":
            //GameOver();
            //break;
            case "Water":
                qc._questionMenu.SetActive(false);
                bc.isTrigger = true;
                _gameManager.GameOver();
                break;
            case "NextLevel":
                _gameManager.NextScene();
                break;
            default:
                break;
        }
        /*if (collider.gameObject.CompareTag("Pickup"))
        {

            PickUp = collider.gameObject;
            //clck.gameObject.SetActive(true);
            SeeQuestion(collider);
            //SeeQuestion(_numberOfQuestion);
            //bool answered = cont.SeeQuestion();
            //GameScore(collider, true);
        }*/

    }
    private void OnTriggerExit2D(Collider2D collider)
    {
        switch (collider.gameObject.tag)
        {
            case "PickUp":
                inRange = PlayerActions.None;
                break;
            default:
                break;
        }
    }
    void OnDrawGizmosSelected()
    {

        // Draw a yellow cube at the transform position
        if (isGrounded)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
        else
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }

    }

}

