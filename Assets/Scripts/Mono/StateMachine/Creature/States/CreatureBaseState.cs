using UnityEngine;

public abstract class CreatureBaseState
{
    public virtual void OnEnter(CreatureManagerBase creature)
    {
        creature.StartCoroutine(WaitAndExit(creature, 2f));
    }

    public abstract void OnExit(CreatureManagerBase creature);
    public abstract void Update(CreatureManagerBase creature);

    protected System.Collections.IEnumerator WaitAndExit(CreatureManagerBase creature, float delay)
    {
        yield return new WaitForSeconds(delay);
        creature.creatureStateManager.OnStateChangeRequested(CreatureStateType.Idling);
    }
}