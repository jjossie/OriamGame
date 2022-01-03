using UnityEngine;

public class PlayerController : PhysicsObject
{

    public float maxSpeed = 9;
    public float jumpSpeed = 16;
    public Animator animator;

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        camera.GetComponent<CameraFollow>().SetTarget(transform);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = jumpSpeed;
            Debug.Log("Jump!");
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y *= 0.5f;
            }
        }
        targetVelocity = move * maxSpeed;

    }

    protected override void SetAnimations()
    {
        float xAxis = Input.GetAxis("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(xAxis));
        bool isJumping = Input.GetButtonDown("Jump");
        if (isJumping) 
            Debug.Log("isJumping");
        animator.SetBool("isJumping", isJumping);
        animator.SetBool("isGrounded", isGrounded);
        if (xAxis > 0)
        {
            // Going Right
            spriteRenderer.flipX = false;
        }
        else if (xAxis < 0)
        {
            // Going Left
            spriteRenderer.flipX = true;
        }
    }

    protected override void Update()
    {
        base.Update();
        if (animator.GetBool("isJumping"))
        {
            Debug.Log("Animator thinks we're jumping this frame");
        }
    }

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

}
