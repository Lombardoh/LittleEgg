public class PlayStationManager : NeedStationManagerBase
{
    private void Start()
    {
        Initialize(NeedType.Boredom, 100, 100, 1);
        GetNeedType();
    }
}
