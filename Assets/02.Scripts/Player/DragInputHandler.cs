using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragInputHandler : MonoBehaviour
{
    public event Action<Vector2, Vector2> OnDragStart;
    public event Action<Vector2, Vector2> OnDragMove;
    public event Action<Vector2, Vector2> OnDragEnd;

    private bool isDragging = false;
    private Vector2 dragStart;

    void Update()
    {
        if (IsPointerOverUI()) return;

        if (Input.GetMouseButtonDown(0))
        {
            dragStart = GetInputPosition();
            isDragging = true;
            OnDragStart?.Invoke(dragStart, dragStart);
        }

        if (Input.GetMouseButton(0) && isDragging)
        {
            var dragCurrent = GetInputPosition();
            OnDragMove?.Invoke(dragStart, dragCurrent);
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            var dragEnd = GetInputPosition();
            isDragging = false;
            OnDragEnd?.Invoke(dragStart, dragEnd);
        }
    }


    private bool IsPointerOverUI()
    {
#if UNITY_EDITOR
        return EventSystem.current != null && EventSystem.current.IsPointerOverGameObject();
#else
        if (Input.touchCount > 0 && EventSystem.current != null)
            return EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId);
        return false;
#endif
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
