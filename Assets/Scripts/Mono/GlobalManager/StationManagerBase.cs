using UnityEngine;

public class StationManagerBase : MonoBehaviour
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

    private (float resourceAmount, NeedType needType) ResourceConsumed()
    {
        if (currentResource == null) return (0f, NeedType.None);

        float resourceValue = currentResource.GetResouceValue();
        NeedType needType = currentResource.GetNeedType();
        Destroy(currentResource.gameObject);
        return (resourceValue, needType);
    }

    private void ResourceRequested(NeedType needType)
    {
        if (currentResource != null)
        {
            Destroy(currentResource.gameObject);
        }
        ResourceManagerBase newResource = Instantiate(resourcePrefab, resourceSpawn);
        newResource.initialize(needType, 100);
        currentResource = newResource;
        StationEvents.OnResourceCreated?.Invoke(needType, currentResource.transform);
    }
}
