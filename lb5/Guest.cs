using System.Runtime.Serialization;

namespace lb5
{
    [DataContract]
    public class Guest
    {
        private static int lastId = 0;
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int NumDays { get; set; }
        [DataMember]
        public decimal CostPerDay { get; set; }
        [DataMember]
        public int NumPeople { get; set; }

        public Guest(int numDays, decimal costPerDay, int numPeople)
        {
            Id = ++lastId;
            NumDays = numDays;
            CostPerDay = costPerDay;
            NumPeople = numPeople;
        }
    }
}
