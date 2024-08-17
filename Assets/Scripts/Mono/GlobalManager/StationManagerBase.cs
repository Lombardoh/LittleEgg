using UnityEngine;

public class StationManagerBase : MonoBehaviour
{
    public Transform resourceSpawn;
    public ResourceManagerBase resourcePrefab;

    private void OnEnable()
    {
        StationEvents.OnResourceRequested += ResourceRequested;
    }    
    private void OnDisable()
    {
        StationEvents.OnResourceRequested -= ResourceRequested;
    }

    private void ResourceRequested(NeedType needType)
    {
        ResourceManagerBase newResource= Instantiate(resourcePrefab, resourceSpawn);
        newResource.initialize(needType, 100);

    }
}
