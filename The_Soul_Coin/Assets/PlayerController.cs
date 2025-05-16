using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]private float speed = 5.0f;
    private Rigidbody2D rb;
    private Animator anim;
    private bool isRunning = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        UpdateAnimation();
    }

    private void Movement()
    {
        float move = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);
        Flip();
    }

    private void Flip()
    {
        if (rb.linearVelocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (rb.linearVelocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void UpdateAnimation()
    {
        bool isWalking = rb.linearVelocity.x != 0;
        anim.SetBool("isWalking", isWalking);
        if (Input.GetKeyDown(KeyCode.LeftShift) && rb.linearVelocity.x != 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x * 2, rb.linearVelocity.y);
            isRunning = true;
            anim.SetBool("isRunning", isRunning);
            anim.SetBool("isWalking", false);
        }
        else
        {
            isRunning = false;
            anim.SetBool("isRunning", isRunning);
        }
    }
}
