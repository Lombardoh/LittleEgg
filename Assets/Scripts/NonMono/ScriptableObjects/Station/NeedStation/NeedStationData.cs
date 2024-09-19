using UnityEngine;

[System.Serializable]
public class NeedStationData
{
    public NeedType needType;
    public NeedStationManagerBase stationPrefab;
    public float maxAmount;
    public float currentAmount;
    public float refillRate;
}
