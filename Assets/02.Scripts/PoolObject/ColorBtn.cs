using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColorBtn : MonoBehaviour
{
    public Image colorImage;
    public TextMeshProUGUI nameText;

    public void Setup(ColorData data)
    {
        colorImage.color = data.GetUnityColor();
        nameText.text = data.Name;
    }
}
