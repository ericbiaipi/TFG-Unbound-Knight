using System.Collections;
using UnityEngine;

public class EnemyMovements : MonoBehaviour
{
    float speed;
    Rigidbody2D rb;
    Animator anim;

    public bool isStatic;
    public bool isWalker;
    public bool isPatrol;
    public bool isFlyingEnemy;
    public bool mustLook;

    Transform player;

    public bool shouldWait;
    public float timeToWait;
    public bool isWaiting;
    public bool walksRight;

    public Transform wallCheck, pitCheck, groundCheck;
    bool walldetected, pitDetected, isGrounded;
    public float detectionRadius;
    public LayerMask whatIsGround;

    public Transform pointA, pointB;
    bool goToA, goToB;


    // Start is called before the first frame update
    void Start()
    {
        goToA = true;
        speed = GetComponent<Enemy>().speed;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        /*if (PlayerController.instance != null)
        {
            player = PlayerController.instance.transform;
        }*/

    }

    // Update is called once per frame
    void Update()
    {
        if (!isFlyingEnemy)
        {
            pitDetected = !Physics2D.OverlapCircle(pitCheck.position, detectionRadius, whatIsGround);
            walldetected = Physics2D.OverlapCircle(wallCheck.position, detectionRadius, whatIsGround);
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, detectionRadius, whatIsGround);

            if ((pitDetected || walldetected) && isGrounded)
            {
                Flip();
            }
            StuckAvoid();
        }



    }

    public void LookAtPlayer()
    {
        if (mustLook)
        {
            if (player.position.x < transform.position.x)
            {
                transform.localScale = new Vector2(1, 1);
            }
            else
            {
                transform.localScale = new Vector2(-1, 1);

            }
        }

    }


    private void FixedUpdate()
    {
        if (isStatic)
        {
            LookAtPlayer();
            anim.SetBool("Idle", true);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        if (isWalker)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            anim.SetBool("Idle", false);

            if (!walksRight)
            {
                rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
            }
        }
        if (isPatrol)
        {

            if (goToA)
            {
                if (!isWaiting)
                {
                    anim.SetBool("Idle", false);
                    rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
                }



                if (Vector2.Distance(transform.position, pointA.position) < 0.2f)
                {

                    if (shouldWait)
                    {
                        StartCoroutine(Waiting());
                    }

                    Flip();
                    goToA = false;
                    goToB = true;
                }
            }

            if (goToB)
            {
                if (!isWaiting)
                {
                    anim.SetBool("Idle", false);
                    rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
                }

                if (Vector2.Distance(transform.position, pointB.position) < 0.2f)
                {
                    if (shouldWait)
                    {
                        StartCoroutine(Waiting());
                    }

                    Flip();
                    goToA = true;
                    goToB = false;
                }
            }
        }
    }

    IEnumerator Waiting()
    {
        anim.SetBool("Idle", true);
        isWaiting = true;
        Flip();
        yield return new WaitForSeconds(timeToWait);
        isWaiting = false;
        anim.SetBool("Idle", false);
        Flip();
    }


    public void Flip()
    {
        walksRight = !walksRight;
        transform.localScale *= new Vector2(-1, transform.localScale.y);
    }

    public void StuckAvoid()
    {
        if ((walldetected || pitDetected) && goToA)
        {
            goToA = false;
            goToB = true;
        }
        else if ((walldetected || pitDetected) && goToB)
        {
            goToA = true;
            goToB = false;
        }
    }
}