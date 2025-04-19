using UnityEngine;
using Newtonsoft.Json;
using System.IO;


[System.Serializable]
public class PlayerData
{
    [Header("변하는 데이터")]
    public int HighScore;
    public ColorID NowColorID;
    public int Coin;
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
