using System;
using System.Collections;
using UnityEngine;

public class FilpRotateObject : MonoBehaviour
{
    public Transform[] pivotPoints; // 고정점 배열
    public float rotationSpeed = 90f;

    private int currentPivotIndex = 0;

    void Update()
    {
        // 회전 중심 위치
        Vector3 pivot = pivotPoints[currentPivotIndex].position;

        // 중심 기준으로 계속 회전
        transform.RotateAround(pivot, Vector3.forward, rotationSpeed * Time.deltaTime);

        // 클릭 시 회전 중심만 변경
        if (Input.GetMouseButtonDown(0))
        {
            currentPivotIndex = (currentPivotIndex + 1) % pivotPoints.Length;
        }
    }
}
