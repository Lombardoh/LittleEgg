public abstract class CreatureBaseState
{
    public abstract void OnEnter(CreatureManagerBase creature);
    public abstract void OnExit(CreatureManagerBase creature);
    public abstract void Update(CreatureManagerBase creature);
}