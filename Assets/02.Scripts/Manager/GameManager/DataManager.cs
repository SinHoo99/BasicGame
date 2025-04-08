using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using static UnityEditor.Progress;

#region DataClass

#endregion
public class DataManager : MonoBehaviour
{    
    public PlayerSO PlayerSO;

    #region ColorData

    public class ColorData
    {
        public ColorID ID;
        public string Name;
        public int R;
        public int G;
        public int B;
    }

    #endregion

    public void Initializer()
    {
        ContainColorData();
    }

    public Dictionary<ColorID, ColorData> ColorDatas = new Dictionary<ColorID, ColorData>();

    public void ContainColorData()
    {
        List<Dictionary<string, string>> resourceColorDataList = CSVReader.Read(ResourcesPath.ColorCSV);

        foreach (var datas in resourceColorDataList)
        {
            ColorData resourceColorData = new ColorData();
            resourceColorData.ID = (ColorID)int.Parse(datas[Data.ID]);
            resourceColorData.Name = datas[Data.Name];
            resourceColorData.R = int.Parse(datas[Data.R]);
            resourceColorData.G = int.Parse(datas[Data.G]);
            resourceColorData.B = int.Parse(datas[Data.B]);
            ColorDatas.Add(resourceColorData.ID, resourceColorData);
        }
    }
}
