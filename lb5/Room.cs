using System;
using System.Runtime.Serialization;

namespace lb5
{
    [DataContract]
    public class Room
    {
        [DataMember]
        public int Beds { get; set; }
        [DataMember]
        public decimal CostPerDay { get; set; }
        [DataMember]
        public bool IsOccupied { get; set; }
        [DataMember]
        public int DaysRemaining { get; set; }
        [DataMember]
        public Guest? Occupant { get; set; }

        public Room(int beds, decimal costPerDay)
        {
            Beds = beds;
            CostPerDay = costPerDay;
            IsOccupied = false;
            DaysRemaining = 0;
            Occupant = null;
        }

        public void Release()
        {
            IsOccupied = false;
            DaysRemaining = 0;
            Occupant = null;
        }

        public void AssignGuest(Guest guest)
        {
            IsOccupied = true;
            Occupant = guest;
            DaysRemaining = guest.NumDays;
        }
    }
}
