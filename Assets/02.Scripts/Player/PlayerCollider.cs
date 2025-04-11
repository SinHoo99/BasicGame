using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"충돌한 오브젝트: {collision.gameObject.name}");
        if (collision.gameObject.CompareTag(Tag.Wall) || collision.gameObject.CompareTag(Tag.Obstacle))
        {
            GameManager.Instance.SavePlayerData();
            EventBus.Publish(new GameOverEvent());
        }
    }
}
