using System.Collections.Generic;
using UnityEngine;

public class NeedStationManagerBase : MonoBehaviour, IInteractable
{
    protected Resource resource;
    protected float refillRate;

    public virtual void Initialize(NeedType needType, float maxAmount, float currentAmount, float refillRate)
    {
        resource = new(needType, maxAmount, currentAmount);
        this.refillRate = refillRate;
    }

    public virtual NeedType GetNeedType()
    {
        return resource.GetNeedType();
    }

    //private (float resourceAmount, NeedType needType) ResourceConsumed(float consumedAmount)
    //{
    //    if (resource == null) return (0f, NeedType.None);

    //    float newValue = Mathf.Max(0, resource.GetResouceValue() - consumedAmount);

    //    resource.SetResouceValue(newValue);

    //    float resourceLeft = Mathf.Max(resource.GetResouceValue(), consumedAmount);
    //    NeedType needType = resource.GetNeedType();
    //    if(resourceLeft < 1) { Destroy(resource.gameObject); }
        
    //    return (resourceLeft, needType);
    //}

    public KeyValuePair<NeedType, float> Interact()
    {
        NeedType needType = resource.GetNeedType();
        float resourceValue = resource.GetResouceValue();
        return new KeyValuePair<NeedType, float>(needType, resourceValue);
    }
}
