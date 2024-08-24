public class CreatureDrinkState : CreatureBaseState
{
    public override void OnEnter(CreatureManagerBase creature)
    {
        creature.animatorManager.UpdateAnimatorValues("IsDrinking", true);
    }

    public override void OnExit(CreatureManagerBase creature)
    {
        creature.animatorManager.UpdateAnimatorValues("IsDrinking", false);
    }

    public override void Update(CreatureManagerBase creature)
    {
    }
}