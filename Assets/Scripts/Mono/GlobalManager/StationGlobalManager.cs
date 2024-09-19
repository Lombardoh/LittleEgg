using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class StationGlobalManager : MonoBehaviour
{
    public List<NeedStationManagerBase> stations;

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
        //stations = new List<StationManagerBase>();
    }

    private void StationRequested(NeedType needType)
    {
        NeedStationDatas datas = (NeedStationDatas)ScriptableManager.Instance.RequestData(ScriptableType.NeedStations);
        NeedStationData data = datas.needStationData[(int)needType];
        NeedStationManagerBase newStation = (NeedStationManagerBase)Instantiate(data.stationPrefab, transform);
        newStation.Initialize(needType, data.maxAmount, data.currentAmount, data.refillRate);
        stations.Add(newStation);
        PlayerInputManager.Instance.SetCurrentStation(newStation);
    }

    private NeedStationManagerBase GetNearestStation(Vector3 position, NeedType needType)
    {
        return stations
            .Where(station => station.GetNeedType() == needType)
            .OrderBy(station => Vector3.Distance(station.transform.position, position))
            .FirstOrDefault();
    }
}
