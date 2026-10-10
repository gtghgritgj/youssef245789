using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveSpeed = 7;
    public float jumpHeight = 7;
    public KeyCode Spacebar = KeyCode.Space;
    public KeyCode L = KeyCode.LeftArrow;
    public KeyCode R = KeyCode.RightArrow;

    public Transform groundCheck;
    public float groundCheckRadius = 0.4f;
    public LayerMask whatIsGround;
    private bool grounded;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if (Input.GetKeyDown(Spacebar) && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
        if (Input.GetKey(L))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (Input.GetKey(R))
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if (anim != null)
        {
            anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
            anim.SetFloat("Height", rb.velocity.y);
            anim.SetBool("Grounded", grounded);
        }
    }
}