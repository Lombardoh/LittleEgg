public interface ITickListener
{
    public void SubscribeToTicks(TickType tickTime)
    {
        TimeEvents.OnRegisterTickListenerRequested.Invoke(this, tickTime);
    }
    public void UnsubscribeToTicks(TickType tickTime)
    {
        TimeEvents.OnRemoveTickListenerRequested.Invoke(this, tickTime);
    }
    public void OnTicked();
}