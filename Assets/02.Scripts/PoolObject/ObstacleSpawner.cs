using System.Collections;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private float coinInterval = 1f;

    private void Start()
    {
        StartCoroutine(SpawnRoutine(Tag.Obstacle, spawnInterval));
        StartCoroutine(SpawnRoutine(Tag.Coin, coinInterval));
    }

    private IEnumerator SpawnRoutine(string tag, float interval)
    {
        while (true)
        {
            SpawnObjectInCameraView(tag);
            yield return new WaitForSeconds(interval);
        }
    }

    private void SpawnObjectInCameraView(string tag)
    {
        PoolObject obj = ObjectPool.Instance.SpawnFromPool(tag);
        if (obj == null)
        {
            Debug.LogWarning($"Ǯ���� '{tag}' ������Ʈ�� ���� �� �����ϴ�.");
            return;
        }

        // ���� ���� ����
        float spawnRangeX = 2.3f;
        float centerX = transform.position.x;
        float centerY = transform.position.y;

        float x = Random.Range(centerX - spawnRangeX, centerX + spawnRangeX);
        float y;

        // ��ֹ��� ���� ��� ȭ�� ���� �ٱ����� ����
        if (tag == Tag.Obstacle || tag == Tag.Coin)
        {
            y = centerY + 1f; // ���� ������ ������Ʈ ���� �ణ ���ʿ��� ��ȯ
        }
        else
        {
            y = centerY;
        }

        obj.transform.position = new Vector3(x, y, 0f);

        if (tag == Tag.Obstacle)
            GameManager.Instance.GetNextObstacleIndex();
    }


}
