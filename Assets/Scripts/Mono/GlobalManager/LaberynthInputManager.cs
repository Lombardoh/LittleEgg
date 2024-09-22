using UnityEngine;
using UnityEngine.EventSystems;

public class LaberynthInputManager : Singleton<LaberynthInputManager>
{
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
                        MoveCreatureToTile();
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

    private void MoveCreatureToTile()
    {

    }

    private void PerformRaycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (!Physics.Raycast(ray, out RaycastHit hit)) return;
        if (!hit.transform.TryGetComponent(out IClickable Clickabe)) return;

        Clickabe.OnClicked();
    }
}
