using System.Collections;
using UnityEngine;

public class Ghost : PoolObject
{
    public float GhostDelay;
    private float _ghostDelayTime;
    public bool MakeGhost;
    public PoolObject GhostPrefab;
    private SpriteRenderer _playerSpriteRenderer;

    void Start()
    {
        this._ghostDelayTime = this.GhostDelay;
        _playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (this.MakeGhost)
        {
            if (this._ghostDelayTime > 0)
            {
                this._ghostDelayTime -= Time.deltaTime;
            }
            else
            {
                CreateGhost();
                this._ghostDelayTime = this.GhostDelay;
            }
        }
    }

    private void CreateGhost()
    {
        PoolObject currentGhost = ObjectPool.Instance.SpawnFromPool(Tag.Ghost);
        if (currentGhost != null)
        {
            currentGhost.transform.position = this.transform.position;
            currentGhost.transform.rotation = this.transform.rotation;
            currentGhost.transform.localScale = this.transform.localScale;
            Sprite currentSprite = _playerSpriteRenderer.sprite;
            SpriteRenderer ghostSpriteRenderer = currentGhost.GetComponent<SpriteRenderer>();
            ghostSpriteRenderer.sprite = currentSprite;
            ghostSpriteRenderer.flipX = _playerSpriteRenderer.flipX;
            StartCoroutine(DeactivateAfterDelay(currentGhost, 0.1f));
        }
    }

    private IEnumerator DeactivateAfterDelay(PoolObject ghost, float delay)
    {
        yield return new WaitForSeconds(delay);
        ghost.gameObject.SetActive(false);
    }

    public void ToggleGhost(bool enable)
    {
        this.MakeGhost = enable;
    }

}
