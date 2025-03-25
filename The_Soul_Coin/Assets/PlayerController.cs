using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float jumpForce = 5.0f;
    private Rigidbody2D rb;
    private Animator anim;
    private bool isGrounded;
    [SerializeField]private LayerMask layerMark;
    [SerializeField] private Transform groundCheck;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void   Update()
    {
        Move();
        UpdateAnimation();
    }

    private void Move()
    {
        //Move
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput*speed, rb.linearVelocity.y);
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        //jump
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, layerMark);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void UpdateAnimation()
    {
        bool isRunning = Mathf.Abs(rb.linearVelocity.x) > 0.1f;
        float yVelocity = rb.linearVelocity.y;
        anim.SetBool("isRunning", isRunning);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("yVelocity", yVelocity);
        if (Input.GetKeyDown(KeyCode.J))
        {
            Attack();
        }
        if(Input.GetKeyDown(KeyCode.Space) && !isGrounded)
        {
            anim.SetTrigger("Attack_Air");
            Invoke(nameof(ResetAttackTrigger), 0.5f);
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, -10f);
        }
    }

    private void Attack()
    {
        anim.SetTrigger("Attack");
        Invoke(nameof(ResetAttackTrigger), 0.4f); // Chỉnh theo thời gian animation
        anim.SetBool("isRunning", false);
    }

    public void ResetAttackTrigger()
    {
        anim.ResetTrigger("Attack");
        anim.ResetTrigger("Attack_Air");
    }



}
