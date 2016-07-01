using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomLayouts : MonoBehaviour {

    public enum TILETYPES
    {
        ROOM = 'r',
        DOOR = 'd',
        EMPTY = 'x'
    }

    public static List<List<string>> ROOMLIST
    {
        get 
        {
            var roomGrid = new List<List<string>>();
            roomGrid.Add(new List<string> {
                "rrdrr",
                "rrrrr",
                "drrrd",
                "rrrrr",
                "rrdrr"
            });
            roomGrid.Add(new List<string>
            {
                "xxxxx",
                "rrrrr",
                "drrrd",
                "rrrrr",
                "xxxxx"
            });
            roomGrid.Add(new List<string>
            {
                "xrdrx",
                "xrrrx",
                "xrrrx",
                "xrrrx",
                "xrdrx"
            });
            roomGrid.Add(new List<string> {
                "rrdrr",
                "rrrrr",
                "rrrrr",
                "rrrrr",
                "rrrrr"
            });
            roomGrid.Add(new List<string> {
                "rrrrr",
                "rrrrr",
                "rrrrr",
                "rrrrr",
                "rrdrr"
            });
            roomGrid.Add(new List<string> {
                "rrrrr",
                "rrrrr",
                "drrrr",
                "rrrrr",
                "rrrrr"
            });
            roomGrid.Add(new List<string> {
                "rrrrr",
                "rrrrr",
                "rrrrd",
                "rrrrr",
                "rrrrr"
            });
            //TODO: add more
            //TODO: account for multiple varieties of each tile type
            //TODO: figure out how to store better
            return roomGrid;
        }
    }

}
