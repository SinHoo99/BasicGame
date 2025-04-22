using System.Collections;
using UnityEngine;

public class Coin : PoolObject
{
    [SerializeField] private GameObject scoreEffectPrefab;
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
            if (scoreEffectPrefab != null)
            {
                Instantiate(scoreEffectPrefab, transform.position, Quaternion.identity);
            }
            gameObject.SetActive(false);
        }
    }
}
