using System;
using UnityEngine;
using UnityEngine.UI;


public class PickColorUI : MonoBehaviour
{
    [SerializeField] private GameObject ColorPickPrefab;
    [SerializeField] private Transform Content;
    [SerializeField] private Image nowColorImg;

    public event Action<Color> OnColorPick;
    private void OnEnable()
    {
        OnColorPick += ShowNowColor;
    }

    private void OnDisable()
    {
        OnColorPick -= ShowNowColor;
    }

    private void Start()
    {
        CreateColorDatas();
    }

    private void ShowNowColor(Color color)
    {
        if (nowColorImg != null)
        {
            nowColorImg.color = color;
        }
    }


    public void CreateColorDatas()
    {
        foreach (var pair in GameManager.Instance.DataManager.ColorDatas)
        {
            ColorData data = pair.Value;

            GameObject go = Instantiate(ColorPickPrefab, Content);
            var item = go.GetComponentInChildren<ColorBtn>();

            if (item != null)
            {
                item.Setup(data);

                // 버튼이 눌렸을 때 실행될 이벤트 등록
                item.OnColorSelected += (pickedColor) =>
                {
                    OnColorPick?.Invoke(pickedColor);
                };
            }
            else
            {
                Debug.LogWarning("ColorPickItem이 프리팹에 없습니다!");
            }
        }
    }
}
