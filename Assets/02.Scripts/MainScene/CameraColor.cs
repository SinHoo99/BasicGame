using UnityEngine;

public class CameraColor : MonoBehaviour
{
    public TimeColorData colorData;
    public float dayDurationInSeconds = 60f; // �Ϸ簡 �� �ʿ� ���� ������� (����׿�)
    private float timeOfDay = 0f;

    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        // �ð� ����
        timeOfDay += Time.deltaTime * (24f / dayDurationInSeconds);
        if (timeOfDay >= 24f) timeOfDay = 0f;

        Color targetColor = GetColorByTime(timeOfDay);
        mainCamera.backgroundColor = Color.Lerp(mainCamera.backgroundColor, targetColor, Time.deltaTime * 0.5f);
    }

    Color GetColorByTime(float hour)
    {
        if (colorData.timeColors == null || colorData.timeColors.Length < 2)
            return Color.black;

        for (int i = 0; i < colorData.timeColors.Length - 1; i++)
        {
            var current = colorData.timeColors[i];
            var next = colorData.timeColors[i + 1];

            if (hour >= current.hour && hour < next.hour)
            {
                float t = Mathf.InverseLerp(current.hour, next.hour, hour);
                return Color.Lerp(current.color, next.color, t);
            }
        }

        // �㿡�� ���� �Ѿ �� ���� ó��
        var last = colorData.timeColors[^1];
        var first = colorData.timeColors[0];

        float wrappedHour = hour < first.hour ? hour + 24f : hour;
        float tWrap = Mathf.InverseLerp(last.hour, 24f + first.hour, wrappedHour);
        return Color.Lerp(last.color, first.color, tWrap);
    }
}