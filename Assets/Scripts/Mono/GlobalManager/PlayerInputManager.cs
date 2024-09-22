using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInputManager : Singleton<PlayerInputManager>
{
    public GameObject floor;
    PlayerControls playerControls;
    public NeedStationManagerBase CurrentStation { get; private set; }

    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();

            playerControls.PlayerActions.LeftClick.performed += context =>
            {
                if (!IsPointerOverUI())
                {
                    if (CurrentStation == null)
                    {
                        PerformRaycast();
                    }
                    else
                    {
                        CreateStation();
                    }
                }
            };
        }
        playerControls.Enable();
    }

    private bool IsPointerOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    void CreateStation()
    {
        if (CurrentStation == null) return;
        CurrentStation.transform.SetParent(floor.transform);
        CreatureEvents.OnNewStationCreated?.Invoke(CurrentStation.GetNeedType());
        CurrentStation = null;
    }

    public void SetCurrentStation(NeedStationManagerBase currentStation)
    {
        this.CurrentStation = currentStation;
    }

    private void Update()
    {
        if (CurrentStation == null) return;

        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Camera.main.WorldToScreenPoint(CurrentStation.transform.position).z;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        CurrentStation.transform.position = worldPosition;
    }

    private void PerformRaycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out RaycastHit hit)) return;

        if (!hit.transform.TryGetComponent(out CreatureRanchManager creature)) return;

        creature.TogglePanel();
    }
}
