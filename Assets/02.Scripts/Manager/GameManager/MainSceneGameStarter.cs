using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
