using UnityEngine;
using UnityEngine.AI;

public class LocomotionManagerBase : MonoBehaviour
{
    public NavMeshAgent agent;

    protected virtual void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    protected virtual void Update()
    {
        if (!agent.hasPath || agent.pathPending || agent.remainingDistance > agent.stoppingDistance) { return; }
        DestinationReached();
    }

    public virtual void SetDestination(Vector3 destination)
    {
        agent.SetDestination(destination);
    }

    protected virtual void DestinationReached()
    {
        agent.isStopped = true;
        agent.ResetPath();
    }
}
