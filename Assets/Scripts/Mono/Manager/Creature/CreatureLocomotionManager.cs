using UnityEngine;

public class CreatureLocomotionManager : LocomotionManagerBase
{
    public CreatureManagerBase creature;

    protected override void Awake()
    {
        base.Awake();
        creature = GetComponent<CreatureManagerBase>();
    }

    public override void MoveToDestination(Vector3 destination)
    {
        base.MoveToDestination(destination);
        creature.creatureStateManager.OnStateChangeRequested(CreatureStateType.Walking);
    }

    protected override void DestinationReached()
    {
        base.DestinationReached();
        creature.interactionManager.InteractWithStation();
    }
}
