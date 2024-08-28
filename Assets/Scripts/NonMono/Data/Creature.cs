using System.Collections.Generic;

public class Creature
{
    public NeedsBase Needs {  get; set; }
    private readonly float needTreshold = 70f;
    public float recoveryRate = 10f;

    public Creature()
    {
        Needs = new(70, 60, 50, 40); 
    }

    public NeedsBase GetNeeds()
    {
        return Needs;
    }

    public bool NeedFullfilled(NeedType needType)
    {
        return Needs.GetNeed(needType) < needTreshold;
    }
}
