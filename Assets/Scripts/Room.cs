using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Room : MonoBehaviour {

    public TileRoom roomTilePrefab;
    public TileDoor doorTilePrefab;
    private IList<Tile> tiles;
    private Vector3 shift;

    public void Generate(IList<string> grid, Vector2 shift)
    {
        this.shift = shift;
        tiles = new List<Tile>();
        for (int i=0; i<grid.Count; i++)
        {
            var curRow = grid[i];
            for (int j=0; j<curRow.Length; j++)
            {
                var curTile = curRow[j];

                Tile newTile;
                if (curTile == (char) RoomLayouts.TILETYPES.ROOM)
                {
                    newTile = Instantiate(roomTilePrefab) as TileRoom;
                    AddTile(newTile, i, j);
                }
                else if (curTile == (char) RoomLayouts.TILETYPES.DOOR)
                {
                    newTile = Instantiate(doorTilePrefab) as TileDoor;
                    AddTile(newTile, i, j);
                }

            }
        }

    }

    public void Reset()
    {
        foreach(Tile tile in tiles)
        {
            tile.Reset();
            Destroy(tile.gameObject);
        }
    }

    private void AddTile (Tile newTile, int i, int j)
    {
        tiles.Add(newTile);
        newTile.name = "Tile " + i + ", " + j;
        newTile.transform.parent = transform;
        newTile.transform.localPosition = new Vector3(
            (shift.x + i) * newTile.transform.lossyScale.x,
            0,
            (shift.y + j) * newTile.transform.lossyScale.z);

    }

}
