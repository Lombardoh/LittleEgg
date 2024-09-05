using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StationDatas", menuName = "ScriptableObjects/StationDatas")]
public class StationDatas : ScriptableObject
{
    [EnumNamedArray(typeof(NeedType))]
    public List<StationData> stationData;
}
