using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NeedStationDatas", menuName = "ScriptableObjects/NeedStationDatas")]
public class NeedStationDatas : ScriptableObject
{
    [EnumNamedArray(typeof(NeedType))]
    public List<NeedStationData> needStationData;
}
