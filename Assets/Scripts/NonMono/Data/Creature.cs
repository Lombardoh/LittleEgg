using System.Collections.Generic;

public class Creature
{
    public NeedsBase Needs {  get; set; }
    private readonly float needTreshold = 70f;

    public Creature()
    {
        Needs = new(70, 60, 50, 40); 
    }

    public List<KeyValuePair<NeedType, float>> GetAllNeeds()
    {
        return Needs.GetAllNeeds();
    }

    public bool NeedFullfilled(NeedType needType)
    {
        return Needs.GetNeed(needType) < needTreshold;
    }

}
