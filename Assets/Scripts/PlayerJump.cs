using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 10f;
    private Rigidbody2D rb;

    public float checkRadius = 0.2f;
    public LayerMask groundLayer;

    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 checkPosition = new Vector2(transform.position.x, transform.position.y - 0.6f); // check directly under player
        isGrounded = Physics2D.OverlapCircle(checkPosition, checkRadius, groundLayer);

        if (isGrounded && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce); // use `velocity` instead of `linearVelocity`
        }
    }

    void OnDrawGizmosSelected()
    {
        Vector2 checkPosition = new Vector2(transform.position.x, transform.position.y - 0.6f);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(checkPosition, checkRadius);
    }
}
