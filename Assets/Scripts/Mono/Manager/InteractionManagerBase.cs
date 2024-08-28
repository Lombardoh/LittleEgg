using UnityEngine;

public class InteractionManagerBase : MonoBehaviour
{
    CreatureManagerBase creature;

    protected virtual void Awake()
    {
        creature = GetComponent<CreatureManagerBase>();
    }

    private void ConsumeResource()
    {
        //var (resourceAmount, needType) = StationEvents.OnResourceConsumed?.Invoke(creature.recoveryRate) ?? (0f, NeedType.None);
        //creature.Needs.SetNeed(needType, -resourceAmount);
        //if (resourceAmount > 0) { return; }
        //target = null;
        //creatureStateManager.OnStateChangeRequested(CreatureStateType.Idling);
    }
}
