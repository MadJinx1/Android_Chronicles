using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Level : MonoBehaviour {

    public Room roomPrefab;

    private IList<Room> rooms;
    private IList<TileDoor> doors;
    
    public void Generate(int maxRooms)
    {
        //TODO: generate full level
        //TODO: need rooms to say where doors are, 
        // need rooms to check if they overlap, need to check for matching doors on selection,
        // need rooms to match doors(internal shifting), need enter and exit (tile properties?)
        rooms = new List<Room>();
        doors = new List<TileDoor>();
        var shift = new Vector2();
        TileDoor baseDoor;

        for (int i = 0; i < maxRooms; i++)
        {
            //TODO: select base door and remove from list
            Room newRoom = Instantiate(roomPrefab) as Room;
            rooms.Add(newRoom);

            var grid = RoomLayouts.ROOMLIST[Random.Range(0, RoomLayouts.ROOMLIST.Count)]; //TODO: need to limit this to rooms with matching doors
            newRoom.Generate(grid, shift);
            //TODO: check if rooms overlap

            foreach (var door in newRoom.GetDoors()) { doors.Add(door); }
            baseDoor = doors[Random.Range(0, doors.Count)];
            doors.Remove(baseDoor);
            shift = newRoom.GetRoomShift() + newRoom.GetLocalDoorShift(baseDoor);
        }

    }

    public void Reset()
    {
        foreach (Room room in rooms)
        {
            room.Reset();
            Destroy(room.gameObject);
        }
    }
}
