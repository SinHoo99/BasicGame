using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAutoScroller : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 2f;
    [SerializeField] private float acceleration = 0.05f;
    private void FixedUpdate()
    {
        scrollSpeed += acceleration * Time.fixedDeltaTime;
        transform.position += Vector3.up * scrollSpeed * Time.fixedDeltaTime;
    }
}
