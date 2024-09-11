using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepStationManager : StationManagerBase
{
    private void Start()
    {
        Initialize(NeedType.Sleep, 100, 100, 1);
        GetNeedType();
    }
}
