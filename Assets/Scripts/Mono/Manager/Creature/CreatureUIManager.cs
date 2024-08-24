using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureUIManager : MonoBehaviour
{
    public Transform needPanel;

    //public void UpdateNeedPanel(NeedType needType)
    //{
    //    float currentValue = creature.Needs.GetNeed(needType);
    //    creature.Needs.SetNeed(needType, Mathf.Min(100, currentValue + 1));

    //    if (currentValue > warningThreshold && !unFullfiledNeeds.Any(need => need.needType == needType))
    //    {
    //        NeedData needData = new(needDatas.needDatas[(int)needType].sprite, needDatas.needDatas[(int)needType].needType);
    //        unFullfiledNeeds.Add(needData);
    //        return;
    //    }

    //    if (currentValue < warningThreshold && unFullfiledNeeds.Any(need => need.needType == needType))
    //    {
    //        var needToRemove = unFullfiledNeeds.FirstOrDefault(need => need.needType == needType);
    //        if (needToRemove == null) return;
    //        unFullfiledNeeds.Remove(needToRemove);
    //    }
    //}

    //public void RotateNeedPanel()
    //{
    //    if (unFullfiledNeeds.Count > 0 && !needPanel.gameObject.activeInHierarchy)
    //    {
    //        UIUtils.TogglePanel(needPanel, true);
    //    }
    //    if (unFullfiledNeeds.Count < 1 && needPanel.gameObject.activeInHierarchy)
    //    {
    //        UIUtils.TogglePanel(needPanel, false);
    //    }
    //    if (unFullfiledNeeds.Count < 1) return;

    //    UIUtils.FitImageToPanel(needPanel, unFullfiledNeeds[currentNeedPanelSpriteIndex].sprite);
    //    currentNeedPanelSpriteIndex = (currentNeedPanelSpriteIndex + 1) % unFullfiledNeeds.Count;
    //}
}
