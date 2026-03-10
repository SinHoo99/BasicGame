using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragInputHandler : MonoBehaviour
{
    public event Action<Vector2, Vector2> OnDragStart;
    public event Action<Vector2, Vector2> OnDragMove;
    public event Action<Vector2, Vector2> OnDragEnd;
    public event Action<Vector2> OnTap; // 탭 이벤트 추가

    public bool IsShortTap { get; private set; } = false;

    private bool isDragging = false;
    private Vector2 dragStart;
    private float startTime;

    [Header("탭 판정 조건")]
    [SerializeField] private float dragThreshold = 0.2f; // 최소 드래그 거리
    [SerializeField] private float timeThreshold = 0.2f; // 최대 탭 지속 시간

    void Update()
    {
        if (IsPointerOverUI()) return;

        if (Input.GetMouseButtonDown(0))
        {
            dragStart = GetInputPosition();
            startTime = Time.time; // 시작 시간 기록
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

            float dragDistance = Vector2.Distance(dragStart, dragEnd);
            float dragDuration = Time.time - startTime;

            IsShortTap = dragDistance < dragThreshold && dragDuration < timeThreshold;

            OnDragEnd?.Invoke(dragStart, dragEnd);

            if (IsShortTap)
            {
                OnTap?.Invoke(dragEnd);
            }
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
