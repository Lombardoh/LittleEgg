using UnityEngine;

public class CreatureLocomotionManager : LocomotionManagerBase
{
    public CreatureRanchManager creature;

    protected override void Awake()
    {
        base.Awake();
        creature = GetComponent<CreatureRanchManager>();
    }

    public override void SetDestination(Vector3 destination)
    {
        base.SetDestination(destination);
        creature.creatureStateManager.OnStateChangeRequested(CreatureStateType.Walking);
    }

    protected override void DestinationReached()
    {
        base.DestinationReached();
        creature.interactionManager.InteractWithStation();
    }
}
