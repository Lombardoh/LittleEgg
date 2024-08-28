using UnityEngine;

public class StationRaycastDetector : RaycastDetectorBase
{
    void Update()
    {
        Ray ray = new(transform.position, transform.forward);
        Physics.Raycast(ray, out RaycastHit hit, rayDistance, detectionLayer);

        if (hit.transform == null) { return; };

        hit.transform.TryGetComponent<StationManagerBase>(out StationManagerBase station);

        if (station == null) { return; }

    }
}