using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PickColorUI : MonoBehaviour
{
    [SerializeField] private GameObject ColorPickPrefab;
    [SerializeField] private Transform Content;

    private void Start()
    {
        CreateColorDatas();
    }

    public void CreateColorDatas()
    {
        foreach (var pair in GameManager.Instance.DataManager.ColorDatas)
        {
            ColorData data = pair.Value;

            GameObject go = Instantiate(ColorPickPrefab, Content);

            var item = go.GetComponent<ColorBtn>();
            if (item != null)
                item.Setup(data);
            else
                Debug.LogWarning("ColorPickItem이 프리팹에 없습니다!");
        }

        Debug.Log($"생성 완료: {GameManager.Instance.DataManager.ColorDatas.Count}개 색상");
    }
}
