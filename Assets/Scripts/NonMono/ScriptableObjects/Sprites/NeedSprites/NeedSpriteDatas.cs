using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NeedSpriteDatas", menuName = "ScriptableObjects/NeedSpriteDatas")]
public class NeedSpriteDatas : ScriptableObject
{
    [EnumNamedArray(typeof(NeedType))]
    public List<NeedSpriteData> needSpriteDatas;
}
