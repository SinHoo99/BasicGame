using UnityEngine;

public class DragIndicator : MonoBehaviour
{
    [SerializeField] private float maxLength = 5f;
    [SerializeField] private Transform originTransform;
    private LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponentInChildren<LineRenderer>();
        lineRenderer.positionCount = 0;
    }

    public void OnDragStart(Vector2 start, Vector2 current)
    {
        UpdateLine(start, current);
    }

    public void OnDragMove(Vector2 start, Vector2 current)
    {
        UpdateLine(start, current);
    }

    public void OnDragEnd(Vector2 start, Vector2 end)
    {
        lineRenderer.positionCount = 0;
    }

    private void UpdateLine(Vector2 start, Vector2 current)
    {
        Vector2 drag = start - current;
        if (drag.magnitude > maxLength)
            drag = drag.normalized * maxLength;

        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, originTransform.position);
        lineRenderer.SetPosition(1, originTransform.position + (Vector3)drag);
    }
}
