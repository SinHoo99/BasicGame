using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Obstacle : PoolObject
{
    private Dictionary<int, Color> scoreColorMap = new Dictionary<int, Color>()
    {
        {10, Color.cyan },
        {20, Color.red },
        {30, Color.blue },
        {40, Color.magenta }
    };

    private bool wasVisible = false;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        UpdateColorByScore(GameManager.Instance.playerCurrentScore);
    }
    void OnBecameVisible()
    {
        wasVisible = true;
    }

    void OnBecameInvisible()
    {
        if (wasVisible)
        {
            gameObject.SetActive(false);
            wasVisible = false; // 다음 활성화를 위해 리셋
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.SavePlayerData();
        EventBus.Publish(new GameOverEvent());
    }

    private void UpdateColorByScore(int score)
    {
        Color resultColor = Color.white;

        foreach (var kvp in scoreColorMap)
        {
            if(score < kvp.Key)
            {
                resultColor = kvp.Value;
                break;
            }
        }

        if(score >= scoreColorMap.Keys.Max())
        {
            resultColor = scoreColorMap[scoreColorMap.Keys.Max()];
        }

        spriteRenderer.color = resultColor; 
    }
}
