using System.Collections;
using System.Collections.Generic;
using Common;
using SimpleJSON;
using UnityEngine;

public class SpaceShipVO : BaseVO
{
    public SpaceShipInfo GetSpaceShipInfo(int level)
    {
        JSONArray dataArray = Data.AsArray;
        if (level > dataArray.Count)
        {
            level = dataArray.Count;
        }

        return JsonUtility.FromJson<SpaceShipInfo>(dataArray[level - 1].ToString());
    }
}
