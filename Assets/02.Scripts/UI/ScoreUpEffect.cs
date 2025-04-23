using UnityEngine;
using TMPro;
using DG.Tweening;

public class ScoreUpEffect : MonoBehaviour
{
    [SerializeField] private float moveUpDistance = 60f; // anchoredPosition ����
    [SerializeField] private float duration = 1f;

    private RectTransform rectTransform;
    private TextMeshProUGUI textMesh;

    private void Awake()
    {
        // �ڽĿ��� Text ã��
        textMesh = GetComponentInChildren<TextMeshProUGUI>();
        rectTransform = GetComponentInChildren<RectTransform>();
    }

    private void OnEnable()
    {
        if (rectTransform == null || textMesh == null)
        {
            Debug.LogWarning("RectTransform �Ǵ� TMP�� �Ҵ���� �ʾҽ��ϴ�.");
            return;
        }

        // anchoredPosition �������� ���� �̵�
        rectTransform.DOAnchorPosY(rectTransform.anchoredPosition.y + moveUpDistance, duration)
                     .SetEase(Ease.OutCubic);

        // ���� ���̱�
        textMesh.DOFade(0f, duration)
                .SetEase(Ease.InOutSine);

        // �ڵ� ����
        Destroy(gameObject, duration);
    }

    public void SetText(string value)
    {
        if (textMesh != null)
        {
            textMesh.text = value;
            var c = textMesh.color;
            textMesh.color = new Color(c.r, c.g, c.b, 1f); // ���� �ʱ�ȭ
        }
    }

    private void OnDestroy()
    {
        DOTween.Kill(gameObject);
    }
}
