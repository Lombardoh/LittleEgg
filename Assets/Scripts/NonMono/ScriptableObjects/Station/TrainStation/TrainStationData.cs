using UnityEngine;

[System.Serializable]
public class TrainStationData
{
    public StatType statType;
    public TrainStationManagerBase stationPrefab;
    public float maxAmount;
    public float currentAmount;
    public float refillRate;
}
