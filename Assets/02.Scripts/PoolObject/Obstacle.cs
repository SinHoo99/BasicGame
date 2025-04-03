using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : PoolObject
{
    private bool wasVisible = false;

    void OnBecameVisible()
    {
        wasVisible = true;
    }

    void OnBecameInvisible()
    {
        if (wasVisible)
        {
            gameObject.SetActive(false);
            wasVisible = false; // ���� Ȱ��ȭ�� ���� ����
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Time.timeScale = 0;
    }
}
