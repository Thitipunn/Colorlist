using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instace;

    #region Dialog
    [SerializeField] private DialogUI dialogUI;
    public DialogUI DialogUI => dialogUI;
    public IInteractable Interactable { get; set; }
    #endregion

    #region key
    public int Redkey = 0;
    public int Bluekey = 0;
    public int Greenkey = 0;
    #endregion

    #region Component
    [SerializeField] private PlayerColor playerColor;
    [SerializeField] private Animator animator;

    private float horizontal;
    private float speed = 4f;
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    public bool canMove = true;

    //crouch
    private float walkSpeed = 4f;
    private bool crouch;
    private float crouchSpeed = 1f;
    [SerializeField] private Transform CeillingCheck;
    [SerializeField] private Collider2D StandCollider;
    //

    private float coyoteTime = 0.2f;
    private float coyoteTimeCounter;

    private float jumpBufferTime = 0.2f;
    private float jumpBufferCounter;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    #endregion

    #region Awake
    private void Awake()
    {
        instace = this;
    }
    #endregion

    #region update
    void Update()
    {
        if (dialogUI.IsOpen) return;

        horizontal = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        if (Input.GetKeyDown(KeyCode.E))
        {
            Interactable?.Interact(this);
        }

        //Froze
        if(Respawn.instance.isFroze == true)
        {
            horizontal = 0;
        }
        //

        if (!IsGrounded())
        {
            animator.SetBool("IsJump", true);
        }
        if (IsGrounded())
        {
            animator.SetBool("IsJump", false);
        }

        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && !Respawn.instance.isFroze && !pauseMenu.GameIsPaused)
        {
            jumpBufferCounter = jumpBufferTime;

            FindObjectOfType<SoundManager>().Play("Jump");
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (jumpBufferCounter > 0f && coyoteTimeCounter > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

            jumpBufferCounter = 0f;
        }
        if(Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

            coyoteTimeCounter = 0f;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            crouch = true;
            Crouch();
        }
        else if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            crouch = false;
            Crouch();
        }
        else if (!crouch)
        {
            Crouch();
        }

        Flip();
    }
    #endregion


    #region fixedUpdate
    void FixedUpdate()
    {
        if(canMove == true)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }       
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private bool IsCrouch()
    {
       return Physics2D.OverlapCircle(CeillingCheck.position, 0.2f, groundLayer);
    }
    
    void Crouch()
    {
        if (crouch)
        {
            if (crouch || IsCrouch())
            {
                animator.SetBool("IsCrawl", true);
                speed = crouchSpeed;
                StandCollider.enabled = false;
            }
        }
        else if (!crouch)
        {
            if (!IsCrouch())
            {
                if (!crouch)
                {
                    animator.SetBool("IsCrawl", false);
                    speed = walkSpeed;
                    StandCollider.enabled = true;
                }
            }
        }
    }
    #endregion

    #region FlipSprite
    private void Flip()
    {
        if(isFacingRight && horizontal <0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    #endregion

    #region collision

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Key") && collision.gameObject.layer == LayerMask.NameToLayer("Red"))
        {
            Redkey++;
            Debug.Log("RedKey = " + Redkey);
        }

        else if (collision.gameObject.CompareTag("Key") && collision.gameObject.layer == LayerMask.NameToLayer("Blue"))
        {
            Bluekey++;
            Debug.Log("BlueKey = " + Bluekey);
        }

        else if(collision.gameObject.CompareTag("Key") && collision.gameObject.layer == LayerMask.NameToLayer("Green"))
        {
            Greenkey++;
            Debug.Log("GreenKey = " + Greenkey);
        }
    }
    #endregion
}
