using System;
using UnityEngine;

public static class StationEvents
{
    public static Action<NeedType> OnResourceRequested;
    public static Action<NeedType, Transform> OnResourceCreated;
    public static Func<float, (float, NeedType)> OnResourceConsumed;
}
