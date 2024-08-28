public class CreatureWanderingState : CreatureBaseState
{
    public override void OnEnter(CreatureManagerBase creature)
    {
        creature.animatorManager.UpdateAnimatorValues("IsIdling", true);
    }

    public override void OnExit(CreatureManagerBase creature)
    {
        creature.animatorManager.UpdateAnimatorValues("IsIdling", false);
    }

    public override void Update(CreatureManagerBase creature)
    {
    }
}