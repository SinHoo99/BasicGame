using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColorBtn : MonoBehaviour
{
    public Image colorImage;
    public TextMeshProUGUI nameText;

    private ColorData currentData;

    public Action<Color> OnColorSelected;

    public void Setup(ColorData data)
    {
        currentData = data;

        colorImage.color = data.GetUnityColor();
        nameText.text = data.Name;
    }

    public void SetColor()
    {
        if (currentData == null)
        {
            Debug.LogWarning("ColorData가 설정되지 않았습니다.");
            return;
        }

        GameManager.Instance.NowPlayerData.NowColorID = currentData.ID;
        GameManager.Instance.SaveAllData();

        OnColorSelected?.Invoke(currentData.GetUnityColor());
    }
}
