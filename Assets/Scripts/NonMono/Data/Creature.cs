using System.Collections.Generic;

public class Creature
{
    public Needs Needs {  get; set; }
    public Stats Stats { get; set; }
    private readonly float needTreshold = 70f;
    public float recoveryRate = 10f;

    public Creature()
    {
        Needs = new(70, 60, 50, 40);
        Stats = new(100, 100, 10, 10, 10, 10);
    }

    public Needs GetNeeds()
    {
        return Needs;
    }    
    
    public Stats GetStats()
    {
        return Stats;
    }

    public bool NeedFullfilled(NeedType needType)
    {
        return Needs.GetNeed(needType) < needTreshold;
    }
}
