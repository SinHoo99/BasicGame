using UnityEngine;

public class ObstacleCollider : MonoBehaviour
{
    private GameManager GM => GameManager.Instance;
    private bool hasScored = false;

    
    private void OnEnable()
    {
        hasScored = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tag.Player) && !hasScored && GM.CurrentState != GameState.GameOver)
        {
            GM.AddScore(1);
            hasScored = true;
        }
    }
}
