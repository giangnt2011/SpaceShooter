using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageVO : BaseVO
{
    private string nameData = "Stage";
    public StageVO()
    {
        LoadData(nameData);
    }
    public StageInfo GetStageInfo(int stage)
    {
        JSONArray dataArray = Data.AsArray;
        if (stage > dataArray.Count)
        {
            stage = dataArray.Count;
        }

        return JsonUtility.FromJson<StageInfo>(dataArray[stage].ToString());
    }
}
