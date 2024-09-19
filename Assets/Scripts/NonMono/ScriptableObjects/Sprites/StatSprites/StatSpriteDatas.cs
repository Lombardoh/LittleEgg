using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StatSpriteDatas", menuName = "ScriptableObjects/StatSpriteDatas")]
public class StatSpriteDatas : ScriptableObject
{
    [EnumNamedArray(typeof(StatType))]
    public List<StatSpriteData> statSpriteDatas;
}
