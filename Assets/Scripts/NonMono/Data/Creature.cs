using System.Collections.Generic;

public class Creature
{
    public NeedsBase Needs {  get; set; }

    public Creature()
    {
        Needs = new(0, 0, 0, 0); 
    }

    public List<KeyValuePair<NeedType, float>> GetAllNeeds()
    {
        return Needs.GetAllNeeds();
    }
}
