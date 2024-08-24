public static class StateFactory
{
    public static CreatureBaseState CreateState(CreatureStateType stateType)
    {
        switch (stateType)
        {
            case CreatureStateType.Idle:
                return new CreatureIdleState();
        }
        return null;
    }
}