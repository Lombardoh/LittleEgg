using UnityEngine;

public abstract class CreatureBaseState
{
    public virtual void OnEnter(CreatureRanchManager creature)
    {
        creature.StartCoroutine(WaitAndExit(creature, 2f));
    }
    public abstract void OnExit(CreatureRanchManager creature);
    public abstract void Update(CreatureRanchManager creature);

    protected System.Collections.IEnumerator WaitAndExit(CreatureRanchManager creature, float delay)
    {
        yield return new WaitForSeconds(delay);
        creature.creatureStateManager.OnStateChangeRequested(CreatureStateType.Idling);
    }
}