using UnityEngine;

public class RaycastDetectorBase : MonoBehaviour, IToggleable
{
    public float rayDistance = 10f;
    public LayerMask detectionLayer;

    public bool Detecting { get; set; } = false;

    public Transform Transform => transform;

    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * rayDistance);
    }
}