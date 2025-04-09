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
                Debug.LogWarning("ColorPickItem�� �����տ� �����ϴ�!");
        }

        Debug.Log($"���� �Ϸ�: {GameManager.Instance.DataManager.ColorDatas.Count}�� ����");
    }
}
