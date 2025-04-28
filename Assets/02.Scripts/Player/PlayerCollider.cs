using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    [SerializeField] private GameObject CoinEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Tag.Obstacle))
        {
            GameManager.Instance.SavePlayerData();
            EventBus.Publish(new GameOverUIEvent());
        }

        if (collision.gameObject.CompareTag(Tag.Coin))
        {
            if (CoinEffect != null)
                CoinEffect.SetActive(true);
            else
                Debug.LogWarning("Player: CoinEffect가 설정되지 않았습니다.");
        }
    }
}
