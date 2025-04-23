using UnityEngine;
using TMPro;
using DG.Tweening;

public class ScoreUpEffect : MonoBehaviour
{
    [SerializeField] private float moveUpDistance = 60f; // anchoredPosition 기준
    [SerializeField] private float duration = 1f;

    private RectTransform rectTransform;
    private TextMeshProUGUI textMesh;

    private void Awake()
    {
        // 자식에서 Text 찾기
        textMesh = GetComponentInChildren<TextMeshProUGUI>();
        rectTransform = GetComponentInChildren<RectTransform>();
    }

    private void OnEnable()
    {
        if (rectTransform == null || textMesh == null)
        {
            Debug.LogWarning("RectTransform 또는 TMP가 할당되지 않았습니다.");
            return;
        }

        // anchoredPosition 기준으로 위로 이동
        rectTransform.DOAnchorPosY(rectTransform.anchoredPosition.y + moveUpDistance, duration)
                     .SetEase(Ease.OutCubic);

        // 알파 줄이기
        textMesh.DOFade(0f, duration)
                .SetEase(Ease.InOutSine);

        // 자동 제거
        Destroy(gameObject, duration);
    }

    public void SetText(string value)
    {
        if (textMesh != null)
        {
            textMesh.text = value;
            var c = textMesh.color;
            textMesh.color = new Color(c.r, c.g, c.b, 1f); // 알파 초기화
        }
    }

    private void OnDestroy()
    {
        DOTween.Kill(gameObject);
    }
}
