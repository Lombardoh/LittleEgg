public class DrinkStationManager : NeedStationManagerBase
{
    private void Start()
    {
        Initialize(NeedType.Thirst, 100, 100, 1);
        GetNeedType();
    }
}
