using UnityEngine;

public class ResourceManagerBase : MonoBehaviour
{
    private Resource resource;

    public void initialize(NeedType needType, float resourceValue)
    {
        resource = new(needType, resourceValue );
    }

    public float GetResouceValue()
    {
        return resource.ResourceValue;
    }    
    public NeedType GetNeedType()
    {
        return resource.needType;
    }
}
