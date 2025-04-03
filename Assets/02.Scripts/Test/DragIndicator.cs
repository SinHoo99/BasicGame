using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class DragIndicator : MonoBehaviour
{
    [SerializeField] private float maxLength = 5f;
    private LineRenderer lineRenderer;
    private DragInputHandler inputHandler;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        inputHandler = GetComponent<DragInputHandler>();

        lineRenderer.positionCount = 0;
        lineRenderer.startWidth = 0.15f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.numCapVertices = 6;
    }

    private void Update()
    {
        if (!inputHandler.IsDragging) return;

        Vector2 force = inputHandler.DragVector;
        if (force.magnitude > maxLength)
            force = force.normalized * maxLength;

        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position + (Vector3)force);
    }

    private void LateUpdate()
    {
        if (!inputHandler.IsDragging)
            lineRenderer.positionCount = 0;
    }
}
