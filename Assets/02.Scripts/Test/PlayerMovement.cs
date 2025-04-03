using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private LineRenderer _lineRenderer;

    private Vector2 dragStart;
    private Vector2 dragCurrent;
    private bool _isDragging = false;

    [SerializeField] private float power = 10f;      // 실제 물리적인 힘
    [SerializeField] private float maxPower = 5f;    // 최대 드래그 길이 제한

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _lineRenderer = GetComponent<LineRenderer>();

        if (_lineRenderer != null)
        {
            _lineRenderer.positionCount = 0;
            _lineRenderer.startWidth = 0.15f;
            _lineRenderer.endWidth = 0.05f;
            _lineRenderer.numCapVertices = 6;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragStart = GetInputPosition();
            _isDragging = true;

            if (_lineRenderer != null)
                _lineRenderer.positionCount = 2;
        }

        if (Input.GetMouseButton(0) && _isDragging)
        {
            dragCurrent = GetInputPosition();
            Vector2 force = CalculateForce();

            if (_lineRenderer != null)
            {
                _lineRenderer.SetPosition(0, _rigidbody2D.position);
                _lineRenderer.SetPosition(1, _rigidbody2D.position + force);
            }
        }

        if (Input.GetMouseButtonUp(0) && _isDragging)
        {
            _isDragging = false;

            if (_lineRenderer != null)
                _lineRenderer.positionCount = 0;

            Vector2 force = CalculateForce();

            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.AddForce(force * power, ForceMode2D.Impulse);
        }
    }

    private Vector2 CalculateForce()
    {
        Vector2 dragVector = dragStart - dragCurrent;
        if (dragVector.magnitude > maxPower)
        {
            dragVector = dragVector.normalized * maxPower;
        }

        return dragVector;
    }

    private Vector2 GetInputPosition()
    {
#if UNITY_EDITOR
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
#else
        if (Input.touchCount > 0)
            return Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        return Vector2.zero;
#endif
    }
}
