public class CreatureSleepState : CreatureBaseState
{
    public override void OnEnter(CreatureManagerBase creature)
    {
        creature.animatorManager.UpdateAnimatorValues("ISleeping", true);
    }

    public override void OnExit(CreatureManagerBase creature)
    {
        creature.animatorManager.UpdateAnimatorValues("ISleeping", false);
    }

    public override void Update(CreatureManagerBase creature)
    {
    }
}