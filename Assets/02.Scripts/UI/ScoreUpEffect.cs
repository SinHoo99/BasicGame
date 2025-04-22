using UnityEngine;
using TMPro;
using DG.Tweening;

public class ScoreUpEffect : MonoBehaviour
{
    [SerializeField] private float moveUpDistance = 1f;
    [SerializeField] private float duration = 1f;

    private TextMeshPro textMesh;

    private void Awake()
    {
        textMesh = GetComponent<TextMeshPro>();
    }

    private void OnEnable()
    {
        // 위로 이동
        transform.DOMoveY(transform.position.y + moveUpDistance, duration)
                 .SetEase(Ease.OutCubic);

        // 투명도 줄이기 (알파 0으로)
        if (textMesh != null)
        {
            textMesh.DOFade(0f, duration).SetEase(Ease.InOutSine);
        }

        // 자동 제거
        Destroy(gameObject, duration);
    }
    private void OnDestroy()
    {
        DOTween.Kill(gameObject);
    }
}
