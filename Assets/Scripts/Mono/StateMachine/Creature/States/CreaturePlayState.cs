public class CreaturePlayState : CreatureBaseState
{
    public override void OnEnter(CreatureManagerBase creature)
    {
        creature.animatorManager.UpdateAnimatorValues("IsPlaying", true);
    }

    public override void OnExit(CreatureManagerBase creature)
    {
        creature.animatorManager.UpdateAnimatorValues("IsPlaying", false);
    }

    public override void Update(CreatureManagerBase creature)
    {
    }
}