using System.Collections;
using UnityEngine;

public class Obstacle : PoolObject
{
    private IObstacleMover mover;

    private void OnEnable()
    {
        StartCoroutine(RetrunObject());
        mover = new RigidbodyMover(); 
        mover.Move(transform);
    }

    private void OnDisable()
    {
        mover?.Stop();
    }

    private IEnumerator RetrunObject()
    {
        yield return new WaitForSeconds(10f);
        gameObject.SetActive(false);
    }

}
