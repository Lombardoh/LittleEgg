public class CreatureWanderingState : CreatureBaseState
{
    public override void OnEnter(CreatureRanchManager creature)
    {
        creature.animatorManager.UpdateAnimatorValues("IsIdling", true);
    }

    public override void OnExit(CreatureRanchManager creature)
    {
        creature.animatorManager.UpdateAnimatorValues("IsIdling", false);
    }

    public override void Update(CreatureRanchManager creature)
    {
    }
}