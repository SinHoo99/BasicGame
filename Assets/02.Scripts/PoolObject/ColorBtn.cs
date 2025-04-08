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
            Debug.LogWarning("ColorData�� �������� �ʾҽ��ϴ�.");
            return;
        }

        Debug.Log($"��ư Ŭ����: ID: {(int)currentData.ID}, �̸�: {currentData.Name}, RGB: ({currentData.R}, {currentData.G}, {currentData.B})");
    }
}
