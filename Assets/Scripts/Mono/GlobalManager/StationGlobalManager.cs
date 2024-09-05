using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StationGlobalManager : MonoBehaviour
{
    public List<StationManagerBase> stations;

    private void OnEnable()
    {
        StationEvents.OnCreateStationRequested += StationRequested;
        StationEvents.OnNearestStationRequested += GetNearestStation;
    }
    
    private void OnDisable()
    {
        StationEvents.OnCreateStationRequested -= StationRequested;
        StationEvents.OnNearestStationRequested -= GetNearestStation;
    }
    private void Awake()
    {
        stations = new List<StationManagerBase>();
    }

    private void StationRequested(NeedType needType)
    {
        StationDatas datas = (StationDatas)ScriptableManager.Instance.RequestData(ScriptableType.Station);
        StationData data = datas.stationData[(int)needType];
        StationManagerBase newStation = (StationManagerBase)Instantiate(data.stationPrefab, transform);
        newStation.Initialize(needType, data.maxAmount, data.currentAmount, data.refillRate);
        stations.Add(newStation);
        PlayerInputManager.Instance.SetCurrentStation(newStation);
    }

    private StationManagerBase GetNearestStation(Vector3 position, NeedType needType)
    {
        var nearestStation = stations
            .Where(station => station.GetNeedType() == needType)
            .OrderBy(station => Vector3.Distance(position, station.transform.position))
            .FirstOrDefault();

        return nearestStation;
    }
}
