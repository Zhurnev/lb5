using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Threading;

namespace lb5
{
    [DataContract]
    public class Hotel
    {
        [DataMember]
        public List<Room> Rooms { get; set; }

        [DataMember]
        public decimal CashRegister { get; set; }

        public Hotel(int[] numBeds, decimal[] costPerDay)
        {
            Rooms = new List<Room>();
            CashRegister = 0;

            for (int i = 0; i < numBeds.Length; i++)
            {
                Room room = new Room(numBeds[i], costPerDay[i]);
                Rooms.Add(room);
            }
        }

        public int FindVacantRoom(Guest guest)
        {
            int roomIndex = -1;
            for (int i = 0; i < Rooms.Count; i++)
            {
                Room room = Rooms[i];
                if (!room.IsOccupied && room.Beds >= guest.NumPeople)
                {
                    roomIndex = i;
                    break;
                }
            }
            return roomIndex;
        }

        public void UpdateCashRegister(decimal amount)
        {
            CashRegister += amount;
        }


        public int GetNumOccupiedRooms()
        {
            int numOccupiedRooms = 0;
            foreach (Room room in Rooms)
            {
                if (room.IsOccupied)
                {
                    numOccupiedRooms++;
                }
            }
            return numOccupiedRooms;
        }

        public bool IsFull()
        {
            return (GetNumOccupiedRooms() == Rooms.Count);
        }
    }
}
