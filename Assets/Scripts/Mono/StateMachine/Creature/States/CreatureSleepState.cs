public class CreatureSleepState : CreatureBaseState
{
    public override void OnEnter(CreatureManagerBase creature)
    {
        creature.animatorManager.UpdateAnimatorValues("IsSleeping", true);
    }

    public override void OnExit(CreatureManagerBase creature)
    {
        creature.animatorManager.UpdateAnimatorValues("IsSleeping", false);
    }

    public override void Update(CreatureManagerBase creature)
    {
    }
}