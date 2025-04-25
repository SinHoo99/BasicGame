using UnityEngine;

public class CameraColor : MonoBehaviour
{
    [Header("Color Settings")]
    public TimeColorData colorData;
    public float dayDurationInSeconds = 60f;
    private float timeOfDay = 0f;

    private Camera mainCamera;

    [Header("Sky Objects")]
    public Transform sun;
    public Transform moon;
    public float curveRadius = 3f;    // 곡선 반지름 (월드 기준)
    public float verticalOffset = 6f; // 카메라 기준 위로 얼만큼

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        // 시간 진행
        timeOfDay += Time.deltaTime * (24f / dayDurationInSeconds);
        if (timeOfDay >= 24f) timeOfDay = 0f;

        // 배경색
        Color targetColor = GetColorByTime(timeOfDay);
        mainCamera.backgroundColor = Color.Lerp(mainCamera.backgroundColor, targetColor, Time.deltaTime * 0.5f);

        // 하늘 오브젝트 위치 갱신
        //UpdateSunAndMoon();
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

        var last = colorData.timeColors[^1];
        var first = colorData.timeColors[0];

        float wrappedHour = hour < first.hour ? hour + 24f : hour;
        float tWrap = Mathf.InverseLerp(last.hour, 24f + first.hour, wrappedHour);
        return Color.Lerp(last.color, first.color, tWrap);
    }

 /*   void UpdateSunAndMoon()
    {
        float t = timeOfDay / 24f;
        Vector3 cameraTop = mainCamera.transform.position + Vector3.up * verticalOffset;

        // 해
        if (sun != null)
        {
            bool isSunVisible = t >= 0.25f && t <= 0.75f;
            if (isSunVisible)
            {
                float sunT = Mathf.InverseLerp(0.25f, 0.75f, t);
                float angle = Mathf.Lerp(180f, 0f, sunT) * Mathf.Deg2Rad;

                float x = Mathf.Cos(angle) * curveRadius;
                float y = Mathf.Sin(angle) * curveRadius;

                sun.position = cameraTop + new Vector3(x, y, 10);
                sun.gameObject.SetActive(true);
            }
            else if (sun.gameObject.activeSelf)
            {
                sun.gameObject.SetActive(false);
            }
        }

        // 달
        if (moon != null)
        {
            bool isMoonVisible = t >= 0.75f || t <= 0.25f;
            if (isMoonVisible)
            {
                float moonT = t >= 0.75f
                    ? Mathf.InverseLerp(0.75f, 1f, t)
                    : Mathf.InverseLerp(0f, 0.25f, t);

                float angle = Mathf.Lerp(180f, 0f, moonT) * Mathf.Deg2Rad;

                float x = Mathf.Cos(angle) * curveRadius;
                float y = Mathf.Sin(angle) * curveRadius;

                moon.position = cameraTop + new Vector3(x, y, 10);
                moon.gameObject.SetActive(true);
            }
            else if (moon.gameObject.activeSelf)
            {
                moon.gameObject.SetActive(false);
            }
        }
    }*/
}
