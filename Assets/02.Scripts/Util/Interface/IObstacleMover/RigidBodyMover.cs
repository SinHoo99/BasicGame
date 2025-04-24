using UnityEngine;

public class RigidbodyMover : IObstacleMover
{
    private Rigidbody2D rb;

    // 원하는 속도 범위 설정
    private float minSpeed = 0.5f;
    private float maxSpeed = 1f;

    public void Move(Transform target)
    {
        rb = target.GetComponent<Rigidbody2D>();

        float cameraCenterX = Camera.main.transform.position.x;

        // 위치에 따라 방향 결정
        Vector2 direction = target.position.x < cameraCenterX
            ? (Vector2.right).normalized
            : (Vector2.left).normalized;

        float randomSpeed = Random.Range(minSpeed, maxSpeed);

        rb.velocity = direction * randomSpeed;

        // 스프라이트 방향 조정
        target.localScale = new Vector3(direction.x > 0 ? 1 : -1, 1, 1);
    }


    public void Stop()
    {
        if (rb != null)
            rb.velocity = Vector2.zero;
    }
}
