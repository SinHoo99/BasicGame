using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float power = 10f;
    [SerializeField] private float maxLength = 5f;

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
}
