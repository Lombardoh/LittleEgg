public class Resource
{
    public float ResourceValue;
    public NeedType needType;

    public Resource(NeedType needType, float resourceValue)
    {
        this.needType = needType;
        ResourceValue = resourceValue;
    }
}
