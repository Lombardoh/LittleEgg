using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotPrefabManager : MonoBehaviour
{
    private Image image;
    private NeedData needData;

    public void Initialize(NeedData needData)
    {
        image = GetComponentInChildren<Image>(true);

        this.needData = needData;
        image.sprite = needData.sprite;
        image.gameObject.SetActive(true);

        if (!image.TryGetComponent<EventTrigger>(out EventTrigger trigger))
        {
            trigger = image.gameObject.AddComponent<EventTrigger>();
        }

        trigger.triggers.Clear();

        EventTrigger.Entry entry = new EventTrigger.Entry
        {
            eventID = EventTriggerType.PointerClick
        };
        entry.callback.AddListener((data) => OnImageClick());
        trigger.triggers.Add(entry);
    }


    private void OnImageClick()
    {
        StationEvents.OnResourceRequested?.Invoke(needData.needType);
    }
}
