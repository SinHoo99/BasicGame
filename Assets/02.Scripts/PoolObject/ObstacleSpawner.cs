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
            Debug.LogWarning($"풀에서 '{tag}' 오브젝트를 꺼낼 수 없습니다.");
            return;
        }

        // 스폰 범위 설정
        float spawnRangeX = 2.3f;
        float centerX = transform.position.x;
        float centerY = transform.position.y;

        float x = Random.Range(centerX - spawnRangeX, centerX + spawnRangeX);
        float y;

        // 장애물과 코인 모두 화면 위쪽 바깥에서 스폰
        if (tag == Tag.Obstacle || tag == Tag.Coin)
        {
            y = centerY + 1f; // 현재 스포너 오브젝트 위로 약간 위쪽에서 소환
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
