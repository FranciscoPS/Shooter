using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb;
    private CapsuleCollider2D col;
    private bool isGrounded;
    private bool facingRight = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CapsuleCollider2D>();
    }

    private void FixedUpdate()
    {
        float moveInput = InputManager.Instance.moveVal;
        rb.linearVelocityX = moveInput * speed;

        if (moveInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && facingRight)
        {
            Flip();
        }

        if (InputManager.JumpWasPressed && isGrounded)
        {
            rb.linearVelocityY = jumpForce;
            InputManager.JumpWasPressed = false;
        }
    }

    private void Update()
    {
        DetectGround();
    }

    private void DetectGround()
    {
        Vector2 raycastOrigin = new Vector2(transform.position.x, col.bounds.min.y);
        float raycastDistance = 0.1f;

        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, Vector2.down, raycastDistance, groundLayer);
        isGrounded = hit.collider != null;
    }

    private void Flip()
    {
        facingRight = !facingRight; 
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
