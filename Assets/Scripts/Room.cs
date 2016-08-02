using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Room : MonoBehaviour {
    //TODO: need to get door orientations from a grid, 
    //  need to be able to shift rooms after creation(*?* accounts for matching doors)
    public TileRoom roomTilePrefab;
    public TileDoor doorTilePrefab;
    private IList<Tile> tiles;
    private Vector2 shift;
    private string roomName;
    
    public void Generate(IList<string> grid, Vector2 shift)
    {
        this.shift = shift;
        roomName = "room_" + shift.x + "x" + shift.y + "y";
        Generate(grid);
        Shift();
    }

    public IList<TileDoor> GetDoors()
    {
        List<TileDoor> doors = new List<TileDoor>();
        foreach (Tile tile in tiles)
        {
            if (tile.GetType() == typeof(TileDoor))
                doors.Add( (TileDoor) tile);
        }
        return doors;
    }

    public Vector2 GetLocalDoorShift(Tile door)
    {
        if (!tiles.Contains(door))
            throw new System.Exception("Door not present in this room");

        Vector2 doorShift = new Vector2();
        doorShift.x = door.transform.localPosition.x;
        doorShift.y = door.transform.localPosition.y;

        return doorShift;
    }

    public Vector2 GetRoomShift()
    {
        return shift;
    }

    public void Reset()
    {
        foreach(Tile tile in tiles)
        {
            tile.Reset();
            Destroy(tile.gameObject);
        }
    }

    public static IList<Orientation> GetOrientations(IList<string> grid)
    {
        var orientations = new List<Orientation>();

        if (grid[0].Contains(((char)RoomLayouts.TILETYPES.DOOR).ToString())) 
        {
            orientations.Add(Orientation.North);
        }

        if (grid[grid.Count-1].Contains(((char)RoomLayouts.TILETYPES.DOOR).ToString()))
        {
            orientations.Add(Orientation.South);
        }

        foreach (var row in grid)
        {
            if (!orientations.Contains(Orientation.West) && row[0] == (char)RoomLayouts.TILETYPES.DOOR)
            {
                orientations.Add(Orientation.West);
            }

            if (!orientations.Contains(Orientation.East) && row[row.Length-1] == (char)RoomLayouts.TILETYPES.DOOR)
            {
                orientations.Add(Orientation.East);
            }
        }

        return orientations;
    }

    private void Generate(IList<string> grid)
    {
        tiles = new List<Tile>();
        for (int i = 0; i < grid.Count; i++)
        {
            var curRow = grid[i];
            for (int j = 0; j < curRow.Length; j++)
            {
                var curTile = curRow[j];

                Tile newTile;
                if (curTile == (char)RoomLayouts.TILETYPES.ROOM)
                {
                    newTile = Instantiate(roomTilePrefab) as TileRoom;
                    AddTile(newTile, i, j);
                }
                else if (curTile == (char)RoomLayouts.TILETYPES.DOOR)
                {
                    newTile = Instantiate(doorTilePrefab) as TileDoor;
                    AddTile(newTile, i, j);
                }

            }
        }

    }

    private void AddTile (Tile newTile, int i, int j)
    {
        newTile.room = this;
        tiles.Add(newTile);
        newTile.name = roomName + "_tile_" + i + "i" + j + "j";
        newTile.transform.parent = transform;
        newTile.transform.localPosition = new Vector3(
            i * newTile.transform.lossyScale.x,
            0,
            j * newTile.transform.lossyScale.z);

    }

    private void Shift()
    {//TODO: account for shifting room back to match doors
        foreach (Tile tile in tiles)
        {
            tile.transform.position = new Vector3(
                shift.x * tile.transform.lossyScale.x,
                0,
                shift.y * tile.transform.lossyScale.z);
        }
    }

    public enum Orientation
    {
        North,
        South,
        East,
        West
    }

}
