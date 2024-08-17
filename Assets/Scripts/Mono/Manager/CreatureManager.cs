using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CreatureManagerBase : MonoBehaviour, ITickListener
{
    private Creature creature;
    public NeedRowManager needRow;
    public Transform statusPanel;
    public Transform needPanel;
    public NeedDatas needDatas;
    private readonly float verticalSpacing = 60f;
    private readonly float warningThreshold = 70;

    private void Awake()
    {
        creature = new Creature();
    }

    private void Start()
    {
        ((ITickListener)this).SubscribeToTicks(TickType.Large);
    }

    public void OnTicked()
    {
        UpdateCreatureNeeds();
        UpdateNeedsUI();
    }

    private void UpdateCreatureNeeds()
    {
        foreach (var need in creature.GetAllNeeds())
        {
            float currentValue = creature.Needs.GetNeed(need.Key);
            creature.Needs.SetNeed(need.Key, Mathf.Min(100, currentValue + 1));
            if (currentValue > warningThreshold) 
            {
                FitImageToPanel(needDatas.needDatas[0].sprite);
            }
        }
    }

    private void UpdateNeedsUI()
    {
        foreach (Transform child in statusPanel)
        {
            Destroy(child.gameObject);
        }

        if (!statusPanel.TryGetComponent<RectTransform>(out RectTransform panelRectTransform)) return;

        float yOffset = panelRectTransform.rect.height / 2 - verticalSpacing;
        foreach (var need in creature.GetAllNeeds())
        {
            NeedRowManager newRow = Instantiate(needRow, statusPanel);
            if (newRow == null) return;

            newRow.SetText(need.Key.ToString(), need.Value.ToString());

            if (!newRow.TryGetComponent<RectTransform>(out var rowRectTransform)) return;

            rowRectTransform.anchoredPosition = new Vector2(0, yOffset);
            yOffset -= verticalSpacing;        
        }
    }

    private void FitImageToPanel(Sprite sprite)
    {
        if(!needPanel.TryGetComponent<Image>(out Image needPanelImage)) return;
        needPanelImage.sprite = sprite;
    }
}
