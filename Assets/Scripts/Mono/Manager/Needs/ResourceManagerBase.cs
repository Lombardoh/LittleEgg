using UnityEngine;

public class ResourceManagerBase : MonoBehaviour
{
    private Resource resource;

    public void Initialize(NeedType needType, float resourceValue)
    {
        resource = new(needType, resourceValue );
    }

    public float GetResouceValue()
    {
        return resource.ResourceValue;
    }        
    public void SetResouceValue(float newValue)
    {
        resource.ResourceValue = newValue;
    }    
    public NeedType GetNeedType()
    {
        return resource.needType;
    }
}
