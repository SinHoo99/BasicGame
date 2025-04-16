using UnityEngine;

public class RigidbodyMover : IObstacleMover
{
    private Rigidbody2D rb;

    // ���ϴ� �ӵ� ���� ����
    private float minSpeed = 0.1f;
    private float maxSpeed = 1f;

    public void Move(Transform target)
    {
        rb = target.GetComponent<Rigidbody2D>();

        // ȭ�� �߽��� ���� ��ǥ ���ϱ�
        float screenCenterX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2f, 0f, 0f)).x;

        // ���� ���� (�����̸� ������, �������̸� ����)
        Vector2 direction = target.position.x < screenCenterX ? Vector2.right : Vector2.left;

        // ���� �ӵ� ����
        float randomSpeed = Random.Range(minSpeed, maxSpeed);

        // �̵� ����
        rb.velocity = direction * randomSpeed;

        // ����: ��������Ʈ ���� ��ȯ
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
