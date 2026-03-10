using UnityEngine;

public class CameraAutoScroller : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 3f;
    private void FixedUpdate()
    {
        transform.position += Vector3.up * scrollSpeed * Time.fixedDeltaTime;
    }
}
