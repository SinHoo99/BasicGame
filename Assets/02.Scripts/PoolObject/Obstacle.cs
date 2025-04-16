using UnityEngine;

public class Obstacle : PoolObject
{
    private bool wasVisible = false;
    private Rigidbody2D rb;
    [SerializeField] private float speed = 1f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        rb.velocity = Vector2.right * speed;
    }

    private void OnDisable()
    {
        wasVisible = false;
        rb.velocity = Vector2.zero;
    }

    private void OnBecameVisible()
    {
        wasVisible = true;
    }

    private void OnBecameInvisible()
    {
        if (wasVisible)
            gameObject.SetActive(false);
    }
}
