using System.Collections;
using UnityEngine;

public class Coin : PoolObject
{
    private void OnEnable()
    {
        StartCoroutine(DisableCoin());
    }

    private IEnumerator DisableCoin()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Tag.Player))
        {
            GameManager.Instance.PlaySFX(SFX.Coin);
            GameManager.Instance.AddScore(1);
            gameObject.SetActive(false);
        }
    }
}
