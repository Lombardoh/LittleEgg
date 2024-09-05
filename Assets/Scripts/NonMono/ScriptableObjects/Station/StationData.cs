using UnityEngine;

[System.Serializable]
public class StationData
{
    public NeedType needType;
    public StationManagerBase stationPrefab;
    public float maxAmount;
    public float currentAmount;
    public float refillRate;
}
