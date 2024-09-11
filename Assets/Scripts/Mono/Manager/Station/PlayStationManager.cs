using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayStationManager : StationManagerBase
{
    private void Start()
    {
        Initialize(NeedType.Boredom, 100, 100, 1);
        GetNeedType();
    }
}
