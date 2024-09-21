public class CreatureSleepState : CreatureBaseState
{
    public override void OnEnter(CreatureRanchManager creature)
    {
        base.OnEnter(creature);
        creature.animatorManager.UpdateAnimatorValues("IsSleeping", true);
        creature.SetNeed(NeedType.Sleep, 1);
    }

    public override void OnExit(CreatureRanchManager creature)
    {
        creature.animatorManager.UpdateAnimatorValues("IsSleeping", false);
    }

    public override void Update(CreatureRanchManager creature)
    {
    }
}