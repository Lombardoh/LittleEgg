using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CreatureUIManager : MonoBehaviour, ITickListener
{
    public Transform needPanel;
    public bool IsActive {  get; private set; } = false;
    public List<NeedData> UnfullfiledNeeds;
    private int currentNeedPanelSpriteIndex = 0;
    private bool isTicking = false;

    public void UpdateNeedPanel(NeedType needType)
    {
        bool exists = UnfullfiledNeeds.Any(needData => needData.needType == needType);

        if (exists){ UnfullfiledNeeds.RemoveAll(needData => needData.needType == needType); return; }

        Sprite sprite = ScriptableManager.Instance.GetNeedSprite(needType);
        NeedData newUnfullfiledNeed = new(sprite, needType);
        UnfullfiledNeeds.Add(newUnfullfiledNeed);
        if(isTicking) return;
        ((ITickListener)this).SubscribeToTicks(TickType.Large);
    }

    public void RotateNeedPanel()
    {
        if (UnfullfiledNeeds.Count > 0 && !needPanel.gameObject.activeInHierarchy)
        {
            UIUtils.TogglePanel(needPanel, true);
        }
        if (UnfullfiledNeeds.Count < 1 && needPanel.gameObject.activeInHierarchy)
        {
            UIUtils.TogglePanel(needPanel, false);
        }
        if (UnfullfiledNeeds.Count < 1) { ((ITickListener)this).UnsubscribeToTicks(TickType.Large);  return; }

        UIUtils.FitImageToPanel(needPanel, UnfullfiledNeeds[currentNeedPanelSpriteIndex].sprite);
        currentNeedPanelSpriteIndex = (currentNeedPanelSpriteIndex + 1) % UnfullfiledNeeds.Count;
    }

    public void OnTicked()
    {
        RotateNeedPanel();
    }
}
