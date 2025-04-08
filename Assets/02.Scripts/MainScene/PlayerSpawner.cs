using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform spawnCheckRoot;
    private Vector3 spawnPos = new Vector3(0, 0, 0); 
    void Start()
    {
        if (!spawnCheckRoot.TryGetComponent<PlayerMarker>(out _))
        {
           Instantiate(playerPrefab, spawnPos, Quaternion.identity);
        }
    }

}
