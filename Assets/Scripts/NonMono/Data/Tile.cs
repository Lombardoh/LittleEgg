public class Tile
{
    private int x;
    private int y;
    private TileType type;

    public Tile(int x, int y, TileType tileType)
    {
        this.x = x;
        this.y = y;
        this.type = tileType;
    }

    public (int x, int y, TileType type) GetTileInfo()
    {
        return (x, y, type);
    }
}
