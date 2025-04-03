using UnityEngine;
using System;

public class DragInputHandler : MonoBehaviour
{
    public event Action<Vector2, Vector2> OnDragUpdate;
    public event Action<Vector2, Vector2> OnDragEnd;

    private Vector2 dragStart;
    private Vector2 dragCurrent;
    private bool isDragging = false;

    public bool IsDragging => isDragging;
    public Vector2 DragVector => dragStart - dragCurrent;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragStart = GetInputPosition();
            isDragging = true;
        }

        if (Input.GetMouseButton(0) && isDragging)
        {
            dragCurrent = GetInputPosition();
            OnDragUpdate?.Invoke(dragStart, dragCurrent);
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            dragCurrent = GetInputPosition();
            isDragging = false;
            OnDragEnd?.Invoke(dragStart, dragCurrent);
        }
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
