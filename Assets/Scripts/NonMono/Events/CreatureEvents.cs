using System;

public static class CreatureEvents
{
    public static Action<NeedType> OnNewStationCreated;
    public static Action<CreatureRanchManager, NeedType, ActionType> OnCreatureWithNeeds;
}