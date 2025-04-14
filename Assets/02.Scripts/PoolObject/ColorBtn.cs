using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ColorBtn : MonoBehaviour
{
    public Image colorImage;
    public Image lockIcon;

    private ColorData currentData;
    private Button myButton;

    public Action<Color> OnColorSelected;

    private void Awake()
    {
        // �� ��ũ��Ʈ�� ��ư�� �پ������Ƿ�, �ڽ����׼� Button ������Ʈ ��������
        myButton = GetComponent<Button>();
    }

    public void Setup(ColorData data)
    {
        currentData = data;

        colorImage.color = data.GetUnityColor();

        bool isUnlocked = GameManager.Instance.NowPlayerData.HighScore >= (int)data.ID;


        if (myButton != null)
        {
            myButton.interactable = isUnlocked;
        }

        // ��� ���� ������ ǥ��
        if (lockIcon != null)
        {
            lockIcon.gameObject.SetActive(!isUnlocked);
        }
    }

    public void SetColor()
    {
        if (currentData == null)
        {
            Debug.LogWarning("ColorData�� �������� �ʾҽ��ϴ�.");
            return;
        }

        // Ȥ�� ���� ���� üũ (��� ����)
        if (GameManager.Instance.NowPlayerData.HighScore < (int)currentData.ID)
        {
            Debug.Log("�� ������ ��� �����Դϴ�.");
            return;
        }

        GameManager.Instance.NowPlayerData.NowColorID = currentData.ID;
        GameManager.Instance.SaveAllData();

        OnColorSelected?.Invoke(currentData.GetUnityColor());
    }
}
