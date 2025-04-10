using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColorBtn : MonoBehaviour
{
    public Image colorImage;
    public TextMeshProUGUI nameText;
    public Image lockIcon;

    private ColorData currentData;
    private Button myButton;

    public Action<Color> OnColorSelected;

    private void Awake()
    {
        // 이 스크립트가 버튼에 붙어있으므로, 자신한테서 Button 컴포넌트 가져오기
        myButton = GetComponent<Button>();
    }

    public void Setup(ColorData data)
    {
        currentData = data;

        colorImage.color = data.GetUnityColor();
        nameText.text = data.Name;

        bool isUnlocked = GameManager.Instance.NowPlayerData.HighScore >= (int)data.ID;
        nameText.text = isUnlocked ? data.Name : "???";


        if (myButton != null)
        {
            myButton.interactable = isUnlocked;
        }

        // 잠금 상태 아이콘 표시
        if (lockIcon != null)
        {
            lockIcon.gameObject.SetActive(!isUnlocked);
        }
    }

    public void SetColor()
    {
        if (currentData == null)
        {
            Debug.LogWarning("ColorData가 설정되지 않았습니다.");
            return;
        }

        // 혹시 몰라서 이중 체크 (방어 로직)
        if (GameManager.Instance.NowPlayerData.HighScore < (int)currentData.ID)
        {
            Debug.Log("이 색상은 잠금 상태입니다.");
            return;
        }

        GameManager.Instance.NowPlayerData.NowColorID = currentData.ID;
        GameManager.Instance.SaveAllData();

        OnColorSelected?.Invoke(currentData.GetUnityColor());
    }
}
