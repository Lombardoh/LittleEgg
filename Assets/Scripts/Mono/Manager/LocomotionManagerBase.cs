using UnityEngine;
using UnityEngine.AI;

public class LocomotionManagerBase : MonoBehaviour
{
    public NavMeshAgent agent;

    protected virtual void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (agent.pathPending || agent.remainingDistance > agent.stoppingDistance || agent.hasPath) { return; }

        DestinationReached();
    }

    public virtual void MoveToDestination(Vector3 destination)
    {
        agent.SetDestination(destination);
    }

    protected virtual void DestinationReached()
    {
        agent.isStopped = true;
        agent.ResetPath();
    }
}
