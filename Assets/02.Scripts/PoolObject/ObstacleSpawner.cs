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

        Vector3 bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 topRight = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));

        float x = Random.Range(bottomLeft.x, topRight.x);
        float y;

        // ��ֹ��� ���� ��� ȭ�� ���� �ٱ����� ����
        if (tag == Tag.Obstacle || tag == Tag.Coin)
        {
            y = topRight.y + 1f;
        }
        else
        {
            y = Random.Range(bottomLeft.y, topRight.y); // Ȥ�� �ٸ� �±װ� ���� ��� ���
        }

        obj.transform.position = new Vector3(x, y, 0f);

        if (tag == Tag.Obstacle)
            GameManager.Instance.GetNextObstacleIndex();
    }


}
