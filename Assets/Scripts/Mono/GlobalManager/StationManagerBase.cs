using UnityEngine;

public class StationManagerBase : MonoBehaviour, IInteractable
{
    public Transform resourceSpawn;
    public ResourceManagerBase resourcePrefab;
    private ResourceManagerBase currentResource;

    private void OnEnable()
    {
        StationEvents.OnResourceRequested += ResourceRequested;
        StationEvents.OnResourceConsumed += ResourceConsumed;
    }    
    private void OnDisable()
    {
        StationEvents.OnResourceRequested -= ResourceRequested;
        StationEvents.OnResourceConsumed -= ResourceConsumed;
    }

    private (float resourceAmount, NeedType needType) ResourceConsumed(float consumedAmount)
    {
        if (currentResource == null) return (0f, NeedType.None);

        float newValue = Mathf.Max(0, currentResource.GetResouceValue() - consumedAmount);

        currentResource.SetResouceValue(newValue);

        float resourceLeft = Mathf.Max(currentResource.GetResouceValue(), consumedAmount);
        NeedType needType = currentResource.GetNeedType();
        if(resourceLeft < 1) { Destroy(currentResource.gameObject); }
        
        return (resourceLeft, needType);
    }

    private void ResourceRequested(NeedType needType)
    {
        if (currentResource != null)
        {
            Destroy(currentResource.gameObject);
        }
        ResourceManagerBase newResource = Instantiate(resourcePrefab, resourceSpawn);
        newResource.Initialize(needType, 100);
        currentResource = newResource;
        StationEvents.OnResourceCreated?.Invoke(needType, currentResource.transform);
    }

    public void Interact()
    {
        throw new System.NotImplementedException();
    }
}
