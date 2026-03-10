using UnityEngine;

[System.Serializable]
public struct TimeColor
{
    [Range(0f, 24f)] public float hour;
    public Color color;
}

[CreateAssetMenu(menuName = "DayNight/Time Color Data")]
public class TimeColorData : ScriptableObject
{
    public TimeColor[] timeColors;
}