public class CreaturePlayState : CreatureBaseState
{
    public override void OnEnter(CreatureRanchManager creature)
    {
        base.OnEnter(creature);
        creature.animatorManager.UpdateAnimatorValues("IsPlaying", true);
        creature.SetNeed(NeedType.Boredom, 1);
    }

    public override void OnExit(CreatureRanchManager creature)
    {
        creature.animatorManager.UpdateAnimatorValues("IsPlaying", false);
    }

    public override void Update(CreatureRanchManager creature)
    {
    }
}