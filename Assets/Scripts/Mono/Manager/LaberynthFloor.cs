using UnityEngine;

public class LaberynthFloor : MonoBehaviour, IClickable
{
    public float tileSize = 4f; 

    public void OnClicked()
    {
        Vector3 clickPosition = GridUtils.GetMouseWorldPosition();
        LaberynthGridEvents.OnGridClicked.Invoke(clickPosition);
    }

}
