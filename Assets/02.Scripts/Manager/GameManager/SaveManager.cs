using UnityEngine;
using Newtonsoft.Json;
using System.IO;


[System.Serializable]
public class PlayerData
{
    [Header("변하는 데이터")]
    public int HighScore;
    public SerializableColor SavedColor;
}

[System.Serializable]
public class SerializableColor
{
    public float r, g, b, a;

    public SerializableColor(Color color)
    {
        r = color.r;
        g = color.g;
        b = color.b;
        a = color.a;
    }
    public Color ToUnityColor() => new Color(r, g, b, a);
}

[System.Serializable]
public class OptionData
{
    [Header("소리")]
    public float BGMVolume;
    public float SFXVolume;
}
public class SaveManager : MonoBehaviour
{
    public void SaveData<T>(T data)
    {
        string path = Path.Combine(Application.persistentDataPath, $"{typeof(T).Name}.json");
        string jsonData = JsonConvert.SerializeObject(data);
        File.WriteAllText(path, jsonData);
    }

    public bool TryLoadData<T>(out T data)
    {
        string path = Path.Combine(Application.persistentDataPath, $"{typeof(T).Name}.json");
        if (File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            data = JsonConvert.DeserializeObject<T>(jsonData);
            return true;
        }
        else
        {
            data = default(T);
            return false;
        }
    }
}
