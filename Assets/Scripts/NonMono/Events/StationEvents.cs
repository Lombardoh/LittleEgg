using System;
using UnityEngine;

public static class StationEvents
{
    public static Action<NeedType> OnCreateStationRequested;
    public static Func<Vector3, NeedType, StationManagerBase> OnNearestStationRequested;
}
