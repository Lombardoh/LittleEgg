public class FoodStationManager : StationManagerBase
{
    private void Start()
    {
        Initialize(NeedType.Hunger, 100, 100, 1);
        GetNeedType();
    }
}
