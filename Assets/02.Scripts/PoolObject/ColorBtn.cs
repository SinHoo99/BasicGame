using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColorBtn : MonoBehaviour
{
    public Image colorImage;
    public TextMeshProUGUI nameText;

    private ColorData currentData;
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

        Debug.Log($"버튼 클릭됨: ID: {(int)currentData.ID}, 이름: {currentData.Name}, RGB: ({currentData.R}, {currentData.G}, {currentData.B})");
    }
}
