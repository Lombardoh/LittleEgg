using System;

public static class TimeEvents
{
    public static Action<ITickListener, TickType> OnRegisterTickListenerRequested;
    public static Action<ITickListener, TickType> OnRemoveTickListenerRequested;
}