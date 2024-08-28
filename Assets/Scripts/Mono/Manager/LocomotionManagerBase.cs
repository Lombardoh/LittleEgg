using UnityEngine;
using UnityEngine.AI;

public class LocomotionManagerBase : MonoBehaviour
{
    public NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (!agent.hasPath || agent.remainingDistance > 5f) { return; }

        DestionationReached();
    }

    public void MoveToDestination(Vector3 destination)
    {
        agent.SetDestination(destination);
    }

    private void DestionationReached()
    {
        Debug.Log("asd");
    }
}
