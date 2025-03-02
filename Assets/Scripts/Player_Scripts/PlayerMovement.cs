using UnityEngine;
[System.Obsolete]

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    public PlayerMovementStats MoveStats;
    [SerializeField] private Collider2D _feetCollider;
    [SerializeField] private Collider2D _bodyCollider;

    private Rigidbody2D _rb;

    // Movement Variables
    private Vector2 _moveVelocity;
    private bool _isFacingRight;

    // Collision Chcek Variables
    private RaycastHit2D _groundHit;
    private RaycastHit2D _headHit;
    private bool _isGrounded;
    private bool _bumpedHead;

    // Jump Variables
    public float VerticalVelocity { get; private set; }

    private void Awake()
    {
        _isFacingRight = true;

        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        CollisionChecks();


        if (_isGrounded)
        {
            Move(MoveStats.GroundAcceleration, MoveStats.GroundDecelaration, InputManager.Movement);
        }
        else
        {
            Move(MoveStats.AirAcceleration, MoveStats.AirDeceleration, InputManager.Movement);
        }
    }

    #region Movement

    private void Move(float acceleration, float deceleration, Vector2 moveInput)
    {
        if (moveInput != Vector2.zero)
        {
            TurnCheck(moveInput);

            Vector2 targetVelocity = Vector2.zero;

            // Esto es para que el personaje se mueva en el eje X, ya sea corriendo o caminando
            if (InputManager.RunIsHold)
            {
                targetVelocity = new Vector2(moveInput.x, 0f) * MoveStats.MaxRunSpeed;
            }
            else
            {
                targetVelocity = new Vector2(moveInput.x, 0f) * MoveStats.MaxWalkSpeed;
            }

            _moveVelocity = Vector2.Lerp(_moveVelocity, targetVelocity, acceleration * Time.fixedDeltaTime);
            _rb.velocity = new Vector2(_moveVelocity.x, _rb.velocity.y);

        }
        else if (moveInput == Vector2.zero)
        {
            _moveVelocity = Vector2.Lerp(_moveVelocity, Vector2.zero, deceleration * Time.fixedDeltaTime);
            _rb.velocity = new Vector2(_moveVelocity.x, _rb.velocity.y);
        }
    }

    private void TurnCheck(Vector2 moveInput)
    {
        // Si el personaje se mueve a la derecha y no esta mirando a la derecha, lo volteo
        if (_isFacingRight && moveInput.x < 0)
        {
            Turn(false);
        }
        // Si el personaje se mueve a la izquierda y no esta mirando a la izquierda, lo volteo
        else if (!_isFacingRight && moveInput.x > 0)
        {
            Turn(true);
        }
    }

    private void Turn(bool faceRight)
    {
        _isFacingRight = faceRight;
        transform.rotation = Quaternion.Euler(0, faceRight ? 0 : 180, 0);
    }

    #endregion

    #region Collision Check

    private void IsGrounded()
    {
        Vector2 boxCastOrigin = new Vector2(_feetCollider.bounds.center.x, _feetCollider.bounds.min.y);
        Vector2 boxCastSize = new Vector2(_feetCollider.bounds.size.x, MoveStats.GroundDetectionRayLength);

        _groundHit = Physics2D.BoxCast(boxCastOrigin, boxCastSize, 0f, Vector2.down, MoveStats.GroundDetectionRayLength, MoveStats.GroundLayer);

        if(_groundHit.collider != null)
        {
            _isGrounded = true;
        }
        else
        {
            _isGrounded = false;
        }

        #region Debug Visualization
        if (MoveStats.DebugShowIsGroundedBox) 
        { 
            Color rayColor = _isGrounded ? Color.green : Color.red;

            Debug.DrawRay(new Vector2(boxCastOrigin.x - boxCastSize.x / 2, boxCastOrigin.y), Vector2.down * MoveStats.GroundDetectionRayLength, rayColor);
            Debug.DrawRay(new Vector2(boxCastOrigin.x * boxCastSize.x / 2, boxCastOrigin.y), Vector2.down * MoveStats.GroundDetectionRayLength, rayColor);
            Debug.DrawRay(new Vector2(boxCastOrigin.x - boxCastSize.x / 2, boxCastOrigin.y - MoveStats.GroundDetectionRayLength), Vector2.right * boxCastSize, rayColor);
        }
        #endregion
    }

    private void CollisionChecks()
    {
        IsGrounded();
    }

    #endregion
}
