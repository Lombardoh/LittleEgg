public class FoodStationManager : NeedStationManagerBase
{
    private void Start()
    {
        Initialize(NeedType.Hunger, 100, 100, 1);
        GetNeedType();
    }
}