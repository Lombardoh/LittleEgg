using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NeedDatas", menuName = "ScriptableObjects/NeedDatas")]
public class NeedDatas : ScriptableObject
{
    [EnumNamedArray(typeof(NeedType))]
    public List<NeedData> needDatas;
}
