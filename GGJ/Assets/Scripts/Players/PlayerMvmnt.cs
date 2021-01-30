using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMvmnt : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    private float moveInput;
    //Dash Movement
    public float dashUnits;
    private float dashTime;
    public float startDashTime;
    private int direction;
    //------------
    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public int extra;
    private int extraJumps;

    private float jumpTimeCounter;
    public float jumpTime;

    private bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        extraJumps = extra;
        dashTime = startDashTime;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (isGrounded)
            extra = extraJumps;
        if(Input.GetKeyDown(KeyCode.Space) && extra > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extra--;
            isJumping = true;
            jumpTimeCounter = jumpTime;
        }
        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
               rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }


        //Dash Movement
        if (!facingRight && Input.GetKeyDown(KeyCode.LeftShift))
        {
            transform.Translate(Vector2.left * dashUnits);
        }
        else if (facingRight && Input.GetKeyDown(KeyCode.LeftShift))
        {
            transform.Translate(Vector2.right * dashUnits);
        }
    }

    private void FixedUpdate()
    {
       

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);


        if (!facingRight && moveInput > 0)
            Flip();
        else if (facingRight && moveInput < 0)
            Flip();
        
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
