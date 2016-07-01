using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level : MonoBehaviour {

    public Room roomPrefab;

    private IList<Room> rooms;
    
    public void Generate(int maxRooms)
    {
        //TODO: generate full level
        //TODO: need rooms to say where doors are, need list of available doors, 
        // need rooms to check if they overlap, need to check for matching doors on selection,
        // need rooms to match doors(internal shifting), need enter and exit (tile properties?)
        //TODO: put code on github!
        rooms = new List<Room>();
        for (int i=0; i<maxRooms; i++)
        {
            Room newRoom = Instantiate(roomPrefab) as Room;
            rooms.Add(newRoom);
            newRoom.Generate(RoomLayouts.ROOMLIST[Random.Range(0, RoomLayouts.ROOMLIST.Count)], new Vector2());
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
