using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float power = 10f;
    [SerializeField] private float maxLength = 5f;
    private bool isJumping = false;
    private bool isFalling = false;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponentInChildren<Rigidbody2D>();
    }

    public void OnDragEnd(Vector2 start, Vector2 end)
    {
        Vector2 drag = start - end;
        if (drag.magnitude > maxLength)
            drag = drag.normalized * maxLength;

        rb.velocity = Vector2.zero;
        rb.AddForce(drag * power, ForceMode2D.Impulse);
    }
    private void FixedUpdate()
    {
        float vy = rb.velocity.y;

        if (!isJumping && vy > 0.1f)
        {
            isJumping = true;
            isFalling = false;
            EventBus.Publish(new PlayerJumpEvent());
        }
        else if (isJumping && !isFalling && vy <= 0f)
        {
            isFalling = true;
            isJumping = false;
            EventBus.Publish(new PlayerFallEvent());
        }
    }

}
