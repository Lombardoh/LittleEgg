using UnityEngine;

public class GridGlobalManager : MonoBehaviour
{
    public int width = 10;
    public int height = 10;
    public float tileSize = 1f;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 pos = new Vector3(x * tileSize + tileSize / 2, 0, y * tileSize + tileSize / 2);
                Gizmos.DrawWireCube(pos, new Vector3(tileSize, 0.1f, tileSize));
            }
        }
    }
}
