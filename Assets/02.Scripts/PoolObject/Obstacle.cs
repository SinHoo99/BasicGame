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
            wasVisible = false; // 다음 활성화를 위해 리셋
        }
    }
}
