using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;
    private float inputVertical;
    public float distance;


    private bool facingRight = true;
    private bool isClimbing;

    private Rigidbody2D rb;

    private bool isGrounded;
    private bool isTransGround;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public LayerMask whatIsLadder;
    public LayerMask whatisTransGround;



    private int extraJumps;
    public int extraJumpValue;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position,checkRadius,whatIsGround);
        isTransGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatisTransGround);
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder);
       
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

       

        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
        Vector3 rotate = transform.eulerAngles;
        if (rotate.z > 90 || rotate.z < -90)
        {
            rotate.z = 0;
        }

        if (hitInfo.collider != null)
        {
           // Debug.Log("ladder");
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                isClimbing = true;
            }
        }
        else 
        { 
            if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                isClimbing = false;
            }
        }
        if (isClimbing == true && hitInfo.collider != null)
        {
            inputVertical = Input.GetAxis("Vertical");
            rb.velocity = new Vector2(rb.velocity.x, inputVertical * speed);
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = 6;
        }
        
    }

    private void Update()
    {
        if (isGrounded == true || isTransGround == true)
        {
            extraJumps = extraJumpValue;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumpValue == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

       
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }

   
}
