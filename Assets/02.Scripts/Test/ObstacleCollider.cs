using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleCollider : MonoBehaviour
{

    private bool hasScored = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasScored)
        {
            Debug.Log("HI");
            hasScored = true;
        }
    }

    private void OnEnable()
    {
        hasScored = false; 
    }

}
