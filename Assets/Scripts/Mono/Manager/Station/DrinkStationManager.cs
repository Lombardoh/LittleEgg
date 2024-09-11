using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkStationManager : StationManagerBase
{
    private void Start()
    {
        Initialize(NeedType.Thirst, 100, 100, 1);
        GetNeedType();
    }
}
