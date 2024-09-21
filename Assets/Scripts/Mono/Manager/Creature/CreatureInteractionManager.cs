using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureInteractionManager : InteractionManagerBase
{
    CreatureRanchManager creature;

    protected override void Awake()
    {
        base.Awake();
        creature = GetComponent<CreatureRanchManager>();
    }

    public void InteractWithStation()
    {
        if (creature.targetStations.Count < 1) return;

        creature.PerforminAction = true;
        NeedType stationType = creature.targetStations[0].GetNeedType();

        switch (stationType)
        {
            case NeedType.Hunger:
                creature.creatureStateManager.OnStateChangeRequested(CreatureStateType.Eating);
                break;
            case NeedType.Thirst:
                creature.creatureStateManager.OnStateChangeRequested(CreatureStateType.Drinking);
                break;
            case NeedType.Boredom:
                creature.creatureStateManager.OnStateChangeRequested(CreatureStateType.Playing);
                break;
            case NeedType.Sleep:
                creature.creatureStateManager.OnStateChangeRequested(CreatureStateType.Sleeping);
                break;
            default:
                return;
        }
    }
}
