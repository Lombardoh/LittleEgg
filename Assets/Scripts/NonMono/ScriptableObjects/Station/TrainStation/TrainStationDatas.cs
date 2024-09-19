using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TrainStationDatas", menuName = "ScriptableObjects/TrainStationDatas")]
public class TrainStationDatas : ScriptableObject
{
    [EnumNamedArray(typeof(StatType))]
    public List<TrainStationData> TrainStationData;
}
