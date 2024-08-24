using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using static TreeEditor.TreeEditorHelper;

public class CreatureManagerBase : MonoBehaviour, ITickListener
{
    private Creature creature;
    private CharacterController characterController;
    private CreatureUIManager creatureUIManager;
    public Transform statusPanel;

    public NeedDatas needDatas;

    private readonly float warningThreshold = 70;
    public Transform target;
    private readonly float speed = 5f;
    public float interactDistance = 3;
    public List<NeedType> UnfullfiledNeedsTypes;

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
        creatureUIManager = GetComponentInChildren<CreatureUIManager>();
        creature = new ();
        UnfullfiledNeedsTypes = new();
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
    }

    private void UpdateCreatureNeeds()
    {
        foreach (var need in creature.GetAllNeeds())
        {
            creature.Needs.SetNeed(need.Key, Mathf.Min(100, need.Value + 1));

            bool isNeedInUnfulfilledNeeds = UnfullfiledNeedsTypes.Any(n => n == need.Key);

            if (need.Value > warningThreshold && !isNeedInUnfulfilledNeeds) { 
                creatureUIManager.UpdateNeedPanel(need.Key);
                UnfullfiledNeedsTypes.Add(need.Key);
            }
            if (need.Value < warningThreshold && isNeedInUnfulfilledNeeds) {
                Debug.Log("here");
                creatureUIManager.UpdateNeedPanel(need.Key);
                UnfullfiledNeedsTypes.Remove(need.Key);
            }
        }
        UIEvens.OnUpdateStatusUI?.Invoke(creature.GetAllNeeds());
    }
}
