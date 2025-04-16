using UnityEngine;

public class Obstacle : PoolObject
{

    private IObstacleMover mover;
    private bool wasVisible = false;

    private void Awake()
    {
     
    }
    private void OnEnable()
    {
        mover = new RigidbodyMover(); 
        mover.Move(transform);
    }

    private void OnDisable()
    {
        mover?.Stop();
        wasVisible = false;
    }

    private void OnBecameVisible()
    {
        wasVisible = true;
    }

    private void OnBecameInvisible()
    {
        if (wasVisible)
            gameObject.SetActive(false);
    }

}
