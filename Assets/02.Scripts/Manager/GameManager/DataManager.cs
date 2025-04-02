using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

#region DataClass

public class DummyData
{
    public DummyDataEnum DummyDataID;
    public string Name;
}

#endregion
public class DataManager : MonoBehaviour
{    
    public void Initialize()
    {
        InitialDummyData();
    }

    public Dictionary<DummyDataEnum, DummyData> DummyDatas = new Dictionary<DummyDataEnum, DummyData>();

    public void InitialDummyData()
    {
        List<Dictionary<string, string>> dummyDataList = CSVReader.Read(ResourcesPath.DummyDataCSV);

        foreach (var datas in dummyDataList)
        {
            DummyData dummyData = new DummyData();

            dummyData.DummyDataID = (DummyDataEnum)int.Parse(datas[Data.DummyDataID]);
            dummyData.Name = datas[Data.Name];
        }
    }

    public DummyData GetDummyData(DummyDataEnum id)
    {
        return DummyDatas[id];
    }
}
