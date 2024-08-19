using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static TreeEditor.TreeEditorHelper;
using System.Linq;

public class CreatureManagerBase : MonoBehaviour, ITickListener
{
    private Creature creature;
    private CharacterController characterController;
    public NeedRowManager needRow;
    public Transform statusPanel;
    public Transform needPanel;
    public NeedDatas needDatas;
    private readonly float verticalSpacing = 60f;
    private readonly float warningThreshold = 70;
    public Transform target;
    private readonly float speed = 5f;
    public float interactDistance = 3;
    public List<NeedData> unFullfiledNeeds;
    private int currentNeedPanelSpriteIndex = 0;


    private void OnEnable()
    {
        StationEvents.OnResourceCreated += ResourceCreated;
    }

    private void OnDisable()
    {
        StationEvents.OnResourceCreated -= ResourceCreated;
    }

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        creature = new ();
        unFullfiledNeeds = new();
    }

    private void Start()
    {
        ((ITickListener)this).SubscribeToTicks(TickType.Large);
    }

    private void Update()
    {
        MoveTowardsTarget();
        if (!TargetReached()) return;
        ConsumeResource();
    }

    private void ConsumeResource()
    {
        var (resourceAmount, needType) = StationEvents.OnResourceConsumed?.Invoke() ?? (0f, NeedType.None);
        creature.Needs.SetNeed(needType, -resourceAmount);
        target = null;
    }

    private void MoveTowardsTarget()
    {
        if (target == null) return;

        Vector3 currentPosition = transform.position;
        Vector3 targetPosition = target.position;
        Vector3 nextPosition = Vector3.MoveTowards(currentPosition, targetPosition, speed * Time.deltaTime);
        characterController.Move(nextPosition - currentPosition);
    }

    private bool TargetReached()
    {
        if (target == null) return false;
        if (Vector3.Distance(target.position, this.transform.position) > interactDistance) return false;

        return true;
    }

    private void ResourceCreated(NeedType needType, Transform target)
    {
        if (creature.NeedFullfilled(needType)) return;
        this.target = target;
    }

    public void OnTicked()
    {
        UpdateCreatureNeeds();
        RotateNeedPanel();
        UpdateNeedsUI();
    }

    private void UpdateCreatureNeeds()
    {
        foreach (var need in creature.GetAllNeeds())
        {
            UpdateNeedPanel(need.Key);
        }
    }

    private void UpdateNeedPanel(NeedType needType)
    {
        float currentValue = creature.Needs.GetNeed(needType);
        creature.Needs.SetNeed(needType, Mathf.Min(100, currentValue + 1));

        if (currentValue > warningThreshold && !unFullfiledNeeds.Any(need => need.needType == needType))
        {
            NeedData needData = new(needDatas.needDatas[(int)needType].sprite, needDatas.needDatas[(int)needType].needType);
            unFullfiledNeeds.Add(needData);
            return;
        }

        if (currentValue < warningThreshold && unFullfiledNeeds.Any(need => need.needType == needType))
        {
            var needToRemove = unFullfiledNeeds.FirstOrDefault(need => need.needType == needType);
            if (needToRemove == null) return;
            unFullfiledNeeds.Remove(needToRemove);
        }
    }

    private void RotateNeedPanel()
    {
        if (unFullfiledNeeds.Count > 0 && !needPanel.gameObject.activeInHierarchy)
        {
            UIUtils.TogglePanel(needPanel, true);
        }
        if (unFullfiledNeeds.Count < 1 && needPanel.gameObject.activeInHierarchy)
        {
            UIUtils.TogglePanel(needPanel, false);
        }
        if (unFullfiledNeeds.Count < 1) return;

        UIUtils.FitImageToPanel(needPanel, unFullfiledNeeds[currentNeedPanelSpriteIndex].sprite);
        currentNeedPanelSpriteIndex = (currentNeedPanelSpriteIndex + 1) % unFullfiledNeeds.Count;
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
}
