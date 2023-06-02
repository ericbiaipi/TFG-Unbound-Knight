using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Variables")]
    public float speed, jumpHeight;
    float velX, velY;

    [Header("Jump Variables")]
    public Transform groundCheck;
    public float radOCircle;
    public LayerMask whatIsGround;
    public bool grounded;

    Rigidbody2D rb;
    Animator myAnimator;

    public static PlayerController instance;

    private void Awake()
    {
        if(instance == null) { instance = this; }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, radOCircle, whatIsGround);

        if (grounded)
        {
            myAnimator.SetBool("Jump", false);
        }
        else
        {
            myAnimator.SetBool("Jump", true);
        }
        
        Flip();
        Attack();
    }

    private void FixedUpdate()
    {
        Movement();
        Jump();
    }

    #region mechanics
    public void Movement()
    {
        velX = Input.GetAxisRaw("Horizontal");
        velY = rb.velocity.y;
        rb.velocity = new Vector2(velX * speed, velY);

        if (rb.velocity.x != 0)
        {
            myAnimator.SetBool("Run", true);
        }
        else
        {
            myAnimator.SetBool("Run", false);
        }
    }

    public void Flip()
    {
        if (velX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (velX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public void Jump() 
    {
        if (Input.GetButton("Jump") && grounded) 
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
    }

    public void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            myAnimator.SetBool("Attack", true);
        }
        else
        {
            myAnimator.SetBool("Attack", false);
        }
    
    }

    #endregion
}