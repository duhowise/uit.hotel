using System;
using Realms;

namespace uit.ooad.Models
{
    public class ServicesDetail : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        public DateTimeOffset Time { get; set; }
        public int Number { get; set; }
        public Booking Booking { get; set; }
        public Service Service { get; set; }
        public long Total => Number * Service.UnitRate;
    }
}
