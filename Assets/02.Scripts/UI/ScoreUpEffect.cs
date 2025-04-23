// ScoreUpEffect.cs
using DG.Tweening;
using TMPro;
using UnityEngine;

public class ScoreUpEffect : MonoBehaviour
{
    [SerializeField] private float moveUpDistance = 60f;
    [SerializeField] private float duration = 1f;

    private RectTransform rectTransform;
    private TextMeshPro textMesh;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        textMesh = GetComponent<TextMeshPro>();
    }

    public void PlayEffect(string value)
    {
        if (textMesh == null || rectTransform == null) return;

        textMesh.text = value;
        var c = textMesh.color;
        textMesh.color = new Color(c.r, c.g, c.b, 1f); // 알파 초기화

        // 이동 애니메이션
        rectTransform.DOAnchorPosY(rectTransform.anchoredPosition.y + moveUpDistance, duration)
                     .SetEase(Ease.OutCubic);

        // 페이드 아웃
        textMesh.DOFade(0f, duration).SetEase(Ease.InOutSine);

        Destroy(gameObject, duration);
    }
}
