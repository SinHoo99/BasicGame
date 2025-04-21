using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnCheckRoot;
    private Vector3 spawnPos = new Vector3(0, 0, 0); 
    void Start()
    {
        if (!spawnCheckRoot.TryGetComponent<PlayerMarker>(out _))
        {
           Instantiate(GameManager.Instance.GetPlayerSOData().PlayerPrefab, spawnPos, Quaternion.identity);
        }
    }
}
