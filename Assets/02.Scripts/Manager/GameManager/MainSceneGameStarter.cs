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
        Info.DOFade(0.4f, 1f) // 1초 동안 투명해졌다가
            .SetLoops(-1, LoopType.Yoyo) // 무한 반복 (투명 ↔ 불투명)
            .SetEase(Ease.InOutSine) // 부드럽게 깜빡임
            .SetUpdate(true);
    }
}
