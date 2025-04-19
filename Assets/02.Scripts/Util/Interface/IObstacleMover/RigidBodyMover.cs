using UnityEngine;

public class RigidbodyMover : IObstacleMover
{
    private Rigidbody2D rb;

    // 원하는 속도 범위 설정
    private float minSpeed = 0.1f;
    private float maxSpeed = 1f;

    public void Move(Transform target)
    {
        rb = target.GetComponent<Rigidbody2D>();

        // 화면 중심의 월드 좌표 구하기
        float screenCenterX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2f, 0f, 0f)).x;

        // 방향 결정 (왼쪽이면 오른쪽, 오른쪽이면 왼쪽)
        Vector2 direction = target.position.x < screenCenterX ? Vector2.right : Vector2.left;

        // 랜덤 속도 설정
        float randomSpeed = Random.Range(minSpeed, maxSpeed);

        // 이동 적용
        rb.velocity = direction * randomSpeed;

        // 선택: 스프라이트 방향 전환
        if (direction.x > 0)
            target.localScale = new Vector3(1, 1, 1);
        else
            target.localScale = new Vector3(-1, 1, 1);
    }

    public void Stop()
    {
        if (rb != null)
            rb.velocity = Vector2.zero;
    }
}
