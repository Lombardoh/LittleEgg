public class SleepStationManager : NeedStationManagerBase
{
    private void Start()
    {
        Initialize(NeedType.Sleep, 100, 100, 1);
        GetNeedType();
    }
}
