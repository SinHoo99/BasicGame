using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private float xRange = 2.5f;
    [SerializeField] private Transform cameraTransform;

    private void Start()
    {
        StartCoroutine(SpawnRoutine());
        //StartCoroutine(SpawnCoinRoutine());
    }
    #region ��ֹ� ����
    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            SpawnObstacle(cameraTransform.position.y + 6f);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnObstacle(float y)
    {
        PoolObject obstacle = ObjectPool.Instance.SpawnFromPool(Tag.Obstacle);

        if (obstacle == null)
        {
            Debug.LogWarning("Ǯ���� ��ֹ��� ���� �� �����ϴ�.");
            return;
        }

        float x = Random.Range(-xRange, xRange);
        obstacle.transform.position = new Vector3(x, y, 0);
        GameManager.Instance.GetNextObstacleIndex();
    }
    #endregion
    #region ���� ����
   /* private IEnumerator SpawnCoinRoutine()
    {
        while (true)
        {
            SpawnCoin(cameraTransform.position.y + 6f);
            yield return new WaitForSeconds(1f);
        }
    }

    private void SpawnCoin(float y)
    {
        PoolObject coin = ObjectPool.Instance.SpawnFromPool(Tag.Coin);

        if (coin == null)
        {
            Debug.LogWarning("Ǯ���� ��ֹ��� ���� �� �����ϴ�.");
            return;
        }

        float x = Random.Range(-xRange, xRange);
        coin.transform.position = new Vector3(x, y, 0);
        GameManager.Instance.GetNextObstacleIndex();
    }*/
    #endregion
}
