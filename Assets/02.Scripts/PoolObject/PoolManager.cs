using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [Header("Obstacle")]
    [SerializeField] private PoolObject Obstacle;
    private int _maxObstacleAmount = 20;

    [Header("Coin")]
    [SerializeField] private PoolObject Coin;
    private int _maxCoinAmount = 20;

    [Header("Ghost")]
    [SerializeField] private PoolObject Ghost;
    private int _maxGhostAmount = 5;

    private void Start()
    {
        AddPoolObject();
    }

    public void AddPoolObject()
    {
        ObjectPool.Instance.AddObjectPool(Tag.Obstacle, Obstacle, _maxObstacleAmount);
        ObjectPool.Instance.AddObjectPool(Tag.Ghost, Ghost, _maxGhostAmount);
        ObjectPool.Instance.AddObjectPool(Tag.Coin, Coin, _maxCoinAmount);
    }
}
