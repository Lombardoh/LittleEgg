using UnityEngine;

public class GridGlobalManager : MonoBehaviour
{
    public int width = 10;
    public int height = 10;
    public float tileSize = 4f;
    public Tile[,] tileGrid;

    private void OnEnable()
    {
        LaberynthGridEvents.OnGridClicked += GetGridInfo;
    }

    private void OnDisable()
    {
        LaberynthGridEvents.OnGridClicked -= GetGridInfo;
    }

    private void Awake()
    {
        tileGrid = new Tile[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                TileType tileType = GetRandomTileType();
                Tile newTile = new(x, y, tileType);
                tileGrid[x, y] = newTile; // Assign the tile to the grid
                Debug.Log($"Created {tileType} tile at: ({x}, {y})");
            }
        }
    }

    private TileType GetRandomTileType()
    {
        return Random.value > 0.5f ? TileType.Floor : TileType.Wall;
    }

    private void GetGridInfo(Vector3 worldPosition)
    {
        int gridX = Mathf.FloorToInt(worldPosition.x / tileSize);
        int gridY = Mathf.FloorToInt(-worldPosition.z / tileSize);

        // Ensure gridX and gridY are within bounds
        if (gridX >= 0 && gridX < width && gridY >= 0 && gridY < height)
        {
            Tile clickedTile = tileGrid[gridX, gridY];
            var tileInfo = clickedTile.GetTileInfo();
            Debug.Log($"Tile clicked at grid position ({gridX}, {gridY}): Type = {tileInfo.type}");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 pos = new Vector3(x * tileSize + tileSize / 2, 0, -(y * tileSize + tileSize / 2));
                Gizmos.DrawWireCube(pos, new Vector3(tileSize, 0.1f, tileSize));
            }
        }
    }

}
