using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [Header("Bullet")]
    [SerializeField] private PoolObject Bullet;
    private int _maxBulletAmount = 20;

    private void Start()
    {
        AddPoolObject();
    }

    public void AddPoolObject()
    {
        ObjectPool.Instance.AddObjectPool(Tag.Bullet, Bullet, _maxBulletAmount);
    }
}
