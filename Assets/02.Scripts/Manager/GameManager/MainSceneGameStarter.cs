using DG.Tweening;
using TMPro;
using UnityEngine;

public class MainSceneGameStarter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Info;

    private void Start()
    {
        StartBlink();
        Time.timeScale = 0;
    }
    public void HidePannel()
    {
        GameManager.Instance.ResetGameState();
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void StartBlink()
    {
        Info.DOFade(0.4f, 1f) // 1�� ���� ���������ٰ�
            .SetLoops(-1, LoopType.Yoyo) // ���� �ݺ� (���� �� ������)
            .SetEase(Ease.InOutSine) // �ε巴�� ������
            .SetUpdate(true);
    }
}
