public class CreatureSleepState : CreatureBaseState
{
    public override void OnEnter(CreatureManagerBase creature)
    {
        base.OnEnter(creature);
        creature.animatorManager.UpdateAnimatorValues("IsSleeping", true);
        creature.SetNeed(NeedType.Sleep, 1);
    }

    public override void OnExit(CreatureManagerBase creature)
    {
        creature.animatorManager.UpdateAnimatorValues("IsSleeping", false);
    }

    public override void Update(CreatureManagerBase creature)
    {
    }
}