using UnityEngine;

public class Coin : PoolObject
{
    private bool wasVisible = false;

    private void OnDisable()
    {
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Tag.Player))
        {
            GameManager.Instance.PlaySFX(SFX.Coin);
           // GameManager.Instance.AddCoin(1);
            gameObject.SetActive(false);
        }
    }
}
