using UnityEngine;

public class CreatureStateManager : MonoBehaviour
{
    public CreatureBaseState currentState;
    private CreatureManagerBase creature;

    private void Start()
    {
        creature = GetComponent<CreatureManagerBase>();
    }

    private void Update()
    {
        if (currentState == null) return;
        currentState.Update(creature);
    }

    public void OnStateChangeRequested(CreatureStateType newState)
    {
        currentState ??= StateFactory.CreateCreatureState(CreatureStateType.Idling);
        currentState.OnExit(creature);
        currentState = StateFactory.CreateCreatureState(newState);
        currentState.OnEnter(creature);
    }

}
