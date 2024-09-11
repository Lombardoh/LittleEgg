public class CreaturePlayState : CreatureBaseState
{
    public override void OnEnter(CreatureManagerBase creature)
    {
        base.OnEnter(creature);
        creature.animatorManager.UpdateAnimatorValues("IsPlaying", true);
        creature.SetNeed(NeedType.Boredom, 1);
    }

    public override void OnExit(CreatureManagerBase creature)
    {
        creature.animatorManager.UpdateAnimatorValues("IsPlaying", false);
    }

    public override void Update(CreatureManagerBase creature)
    {
    }
}