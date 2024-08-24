public static class StateFactory
{
    public static CreatureBaseState CreateCreatureState(CreatureStateType stateType)
    {
        switch (stateType)
        {
            case CreatureStateType.Idling:
                return new CreatureIdleState();            
            case CreatureStateType.Walking:
                return new CreatureWalkState();         
            case CreatureStateType.Eating:
                return new CreatureEatState();         
            case CreatureStateType.Playing:
                return new CreaturePlayState();         
            case CreatureStateType.Sleeping:
                return new CreatureSleepState();         
            case CreatureStateType.Drinking:
                return new CreatureDrinkState();
        }
        return null;
    }
}