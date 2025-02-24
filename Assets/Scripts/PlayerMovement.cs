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

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CapsuleCollider2D>(); // Guardamos la referencia al collider para evitar llamadas innecesarias
    }

    private void FixedUpdate()
    {
        rb.linearVelocityX = InputManager.Instance.moveVal * speed;

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
}
