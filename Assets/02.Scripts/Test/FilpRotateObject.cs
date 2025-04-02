using System;
using System.Collections;
using UnityEngine;

public class FilpRotateObject : MonoBehaviour
{
    public Transform[] pivotPoints; // ������ �迭
    public float rotationSpeed = 90f;

    private int currentPivotIndex = 0;

    void Update()
    {
        // ȸ�� �߽� ��ġ
        Vector3 pivot = pivotPoints[currentPivotIndex].position;

        // �߽� �������� ��� ȸ��
        transform.RotateAround(pivot, Vector3.forward, rotationSpeed * Time.deltaTime);

        // Ŭ�� �� ȸ�� �߽ɸ� ����
        if (Input.GetMouseButtonDown(0))
        {
            currentPivotIndex = (currentPivotIndex + 1) % pivotPoints.Length;
        }
    }
}
