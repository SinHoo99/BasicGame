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
        // ���� �̵�
        transform.DOMoveY(transform.position.y + moveUpDistance, duration)
                 .SetEase(Ease.OutCubic);

        // ���� ���̱� (���� 0����)
        if (textMesh != null)
        {
            textMesh.DOFade(0f, duration).SetEase(Ease.InOutSine);
        }

        // �ڵ� ����
        Destroy(gameObject, duration);
    }
    private void OnDestroy()
    {
        DOTween.Kill(gameObject);
    }
}
