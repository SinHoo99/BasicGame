using UnityEngine;

public class RigidbodyMover : IObstacleMover
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private float minSpeed = 0.5f;
    private float maxSpeed = 1f;

    public void Init(Transform target)
    {
        rb = target.GetComponent<Rigidbody2D>();
        spriteRenderer = target.GetComponent<SpriteRenderer>();
    }

    public void Move(Transform target)
    {
        if (rb == null || spriteRenderer == null)
            Init(target);

        float cameraCenterX = Camera.main.transform.position.x;

        Vector2 direction = target.position.x < cameraCenterX
            ? Vector2.right
            : Vector2.left;

        float randomSpeed = Random.Range(minSpeed, maxSpeed);

        rb.velocity = direction * randomSpeed;

        if (spriteRenderer != null)
            spriteRenderer.flipX = direction.x < 0;
    }

    public void Stop()
    {
        if (rb != null)
            rb.velocity = Vector2.zero;
    }
}
