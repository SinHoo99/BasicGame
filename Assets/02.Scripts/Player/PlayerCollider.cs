using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Tag.Wall) || collision.gameObject.CompareTag(Tag.Obstacle))
        {
            GameManager.Instance.SavePlayerData();
            EventBus.Publish(new GameOverEvent());
        }
    }
}
