using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [Header("Obstacle")]
    [SerializeField] private PoolObject Obstacle;
    private int _maxObstacleAmount = 20;

    [Header("Coin")]
    [SerializeField] private PoolObject Coin;
    private int _maxCoinAmount = 20;
    private void Start()
    {
        AddPoolObject();
    }

    public void AddPoolObject()
    {
        ObjectPool.Instance.AddObjectPool(Tag.Obstacle, Obstacle, _maxObstacleAmount);
        ObjectPool.Instance.AddObjectPool(Tag.Coin, Coin, _maxCoinAmount);
    }
}
