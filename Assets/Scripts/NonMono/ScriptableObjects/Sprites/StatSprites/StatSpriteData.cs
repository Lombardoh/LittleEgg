using UnityEngine;

[System.Serializable]
public class StatSpriteData
{
    public Sprite sprite;
    public StatType statType;

    public StatSpriteData(Sprite sprite, StatType statType)
    {
        this.sprite = sprite;
        this.statType = statType;
    }
}
