using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LaberynthAssetDatas", menuName = "ScriptableObjects/LaberynthAssetDatas")]
public class LaberynthAssetDatas : ScriptableObject
{
    [EnumNamedArray(typeof(TileType))]
    public List<LaberynthAssetData> laberynthAssetDatas;
}
