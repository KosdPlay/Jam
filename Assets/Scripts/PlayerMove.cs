using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : Sounds
{

    private Rigidbody2D rb;
    [SerializeField] private bool soil;
    [SerializeField] private GameObject tail;
    [SerializeField] private GameObject dust;

    private float horizontalMove;
    [SerializeField] private int jumpsRemaining;
    private bool facingRight = true;

    [SerializeField] private int maxJumps;
    private bool DoubleJump;

    private bool canJump;
    private bool hasLanded = false;

    [Header("Player Movement Settings")]
    [Range(0, 100f)] [SerializeField] private float speed;
    [Range(0, 100f)] [SerializeField] private float speedAtHandsBusy;
    [Range(0, 100f)] [SerializeField] private float jumpForce;

    [Space]
    [Header("Player Animation Settings")]
    [SerializeField] private Animator animator;

    [SerializeField] private GameObject mobile—ontrolPanel;

    [Space]
    [Header("Ground Checker Settings")]
    [SerializeField] private bool isGrounded;
    [Range(-5, 5f)] [SerializeField] private float checkGroundOffsetY;
    [Range(0, 15f)] [SerializeField] private float checkGroundRadius;
    [SerializeField] private LayerMask groundLayer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (SelectPlayerInput.instance.isMobile == true)
        {
            mobile—ontrolPanel.SetActive(true);
        }
        else
        {
            mobile—ontrolPanel.SetActive(false);
        }

    }

    private void Update()
    {
        if (Time.timeScale == 1)
        {
            Jamp();
            if (SelectPlayerInput.instance.isMobile == false)
            {

                horizontalMove = Input.GetAxisRaw("Horizontal") * speed;
            }
            else
            {

            }

            if (facingRight && horizontalMove < 0)
            {
                Flip();
            }
            else if (!facingRight && horizontalMove > 0)
            {
                Flip();
            }
        }
    }

    public void Left()
    {
        horizontalMove = -1 * speed;
    }

    public void Right()
    {
        horizontalMove = 1 * speed;
    }

    public void ButtonUp()
    {
        horizontalMove = 0;
    }

    private void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(horizontalMove, rb.velocity.y);
        rb.velocity = targetVelocity;

        GroundChecker();

        //AnimationPlayer();
    }

    public void PlaySoundWalking()
    {
        if (soil)
        {
            PlaySound(sounds[Random.Range(0, 1)]);
        }
        else
        {
            PlaySound(sounds[Random.Range(2, 4)]);
        }
    }

    private void Jamp()
    {
        if (isGrounded)
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }

        if (SelectPlayerInput.instance.isMobile == false)
        {
            if (canJump && Input.GetKeyDown(KeyCode.Space))
            {
                DoJump();
                jumpsRemaining = maxJumps - 1;

            }
            else if (!isGrounded && jumpsRemaining > 0 && Input.GetKeyDown(KeyCode.Space))
            {
                DoubleJump = true;
                DoJump();
                jumpsRemaining--;
            }
        }
        else
        {

        }
    }

    public void Do()
    {
        if (canJump)
        {
            DoJump();
            jumpsRemaining = maxJumps - 1;

        }
        else if (!isGrounded && jumpsRemaining > 0)
        {
            DoubleJump = true;
            DoJump();
            jumpsRemaining--;
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void GroundChecker()
    {
        float checkRadius = checkGroundRadius;
        Vector2 checkPosition = new Vector2(transform.position.x, transform.position.y + checkGroundOffsetY);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(checkPosition, checkRadius, groundLayer);

        isGrounded = false;

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                DoubleJump = false;
                isGrounded = true;
                rb.gravityScale = 2;
                if (colliders[i].CompareTag("Soil"))
                {
                    soil = true;
                }
                else if (colliders[i].CompareTag("Stone"))
                {
                    soil = false;
                }

                if (!hasLanded)
                {
                    if (soil)
                    {
                        PlaySound(sounds[Random.Range(5, 6)]);
                    }
                    else
                    {

                        PlaySound(sounds[7]);

                    }

                    //GameObject gameObject = Instantiate(dust, transform);
                    //gameObject.transform.localPosition = new Vector3(0, -1f, 0);
                    //gameObject.transform.localScale = transform.localScale;
                    //Destroy(gameObject, 0.4f);
                    //animator.Play("JumpDown");

                    hasLanded = true;
                }

                break;
            }
        }

        if (!isGrounded)
        {
            hasLanded = false;
        }
    }



    //private void AnimationPlayer()
    //{
    //    animator.SetFloat("HorizontalMove", Mathf.Abs(horizontalMove));

    //    if (DoubleJump == true && !isGrounded)
    //    {
    //        animator.SetBool("DoubleJumping", true);
    //        animator.SetBool("Jumping", false);
    //    }
    //    else if (isGrounded && DoubleJump == false)
    //    {
    //        animator.SetBool("Jumping", false);
    //        animator.SetBool("DoubleJumping", false);
    //    }
    //    else
    //    {
    //        animator.SetBool("Jumping", true);
    //        animator.SetBool("DoubleJumping", false);
    //    }
    //}

    public int GetMaxJumps()
    {
        return maxJumps;
    }


    public void SetMaxJumps(int max)
    {
        maxJumps = max;
    }

    private void DoJump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }

    public bool GetGround()
    {
        return isGrounded;
    }

    //void Tail()
    //{
    //    GameObject gameObject = Instantiate(tail, transform);
    //    gameObject.transform.localPosition = new Vector3(-0.5f, -0.8f, 0);
    //    gameObject.transform.localScale = transform.localScale;
    //    Destroy(gameObject, 0.4f);

    //}
}
