using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoproffAssignment1.Model
{
    public class Room
    {

        public int RoomID { get; set; }
        public List<Row> Rows { get; set; }

        private static List<Room> rooms = new List<Room>();

        // Represents a read-only list of all rooms
        public static IReadOnlyList<Room> AllRooms => rooms;

        static Room()
        {
            InitializeRooms();
        }

        private static void InitializeRooms()
        {
            var allRows = Row.AllRows.ToList();

            Room room1 = new Room(1);
            room1.Rows.Add(allRows.Where(x=> x.RowId == 1).FirstOrDefault());
            room1.Rows.Add(allRows.Where(x => x.RowId == 2).FirstOrDefault());

            Room room2 = new Room(2);
            room2.Rows.Add(allRows.Where(x => x.RowId == 3).FirstOrDefault());

        }

        public Room(int roomId)
        {
            RoomID = roomId;
            Rows = new List<Row>();
            rooms.Add(this);
        }

    }
}

