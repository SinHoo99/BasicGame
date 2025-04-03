using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [Header("Obstacle")]
    [SerializeField] private PoolObject Obstacle;
    private int _maxObstacleAmount = 20;

    private void Start()
    {
        AddPoolObject();
    }

    public void AddPoolObject()
    {
        ObjectPool.Instance.AddObjectPool(Tag.Obstacle, Obstacle, _maxObstacleAmount);
    }
}
