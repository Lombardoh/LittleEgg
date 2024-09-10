using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CreatureDatas", menuName = "ScriptableObjects/CreatureDatas")]
public class CreatureDatas : ScriptableObject
{
    public List<CreatureData> data;
}
