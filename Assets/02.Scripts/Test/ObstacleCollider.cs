using UnityEngine;

public class ObstacleCollider : MonoBehaviour
{
    private bool hasScored = false;
    private void OnEnable()
    {
        hasScored = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasScored)
        {
            Debug.Log("HI");
            hasScored = true;
        }
    }
}
