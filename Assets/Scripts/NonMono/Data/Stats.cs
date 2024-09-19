using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Stats
{
    public Dictionary<StatType, float> stats { get; set; }

    public Stats(float HP, float MP, float strenght, float defense, float dexterity, float inteligence)
    {
        stats = new Dictionary<StatType, float>
        {
            { StatType.HP, HP },
            { StatType.MP, MP},
            { StatType.Strenght, strenght},
            { StatType.Defense, defense },
            { StatType.Dexterity, dexterity },
            { StatType.Inteligence, inteligence },
        };
    }

    public float GetNeed(StatType statType)
    {
        if (statType == StatType.None) { return 0; }
        return stats[statType];
    }

    public void SetNeed(StatType statType, float value)
    {
        float clampedValue = Mathf.Clamp(value, 0, 100);
        stats[statType] = clampedValue;
    }


    public List<KeyValuePair<StatType, float>> GetAllNeeds()
    {
        return stats.Where(stat => stat.Key != StatType.None).ToList();
    }
}
