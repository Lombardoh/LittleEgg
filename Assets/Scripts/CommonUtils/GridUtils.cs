using UnityEngine;

public static class GridUtils
{
    public static Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out RaycastHit hit)) return Vector3.zero;

        return hit.point;
    }
}
