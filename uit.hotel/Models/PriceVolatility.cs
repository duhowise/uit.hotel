using System;
using System.Collections.Generic;
using Realms;

namespace uit.hotel.Models
{
    public class PriceVolatility : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public long HourPrice { get; set; }
        public long DayPrice { get; set; }
        public long NightPrice { get; set; }
        public DateTimeOffset EffectiveStartDate { get; set; }
        public DateTimeOffset EffectiveEndDate { get; set; }
        public bool EffectiveOnMonday { get; set; }
        public bool EffectiveOnTuesday { get; set; }
        public bool EffectiveOnWednesday { get; set; }
        public bool EffectiveOnThursday { get; set; }
        public bool EffectiveOnFriday { get; set; }
        public bool EffectiveOnSaturday { get; set; }
        public bool EffectiveOnSunday { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public Employee Employee { get; set; }
        public RoomKind RoomKind { get; set; }

        public static PriceVolatility operator +(PriceVolatility a, PriceVolatility b)
        => new PriceVolatility()
        {
            HourPrice = a.HourPrice + b.HourPrice,
            DayPrice = a.DayPrice + b.DayPrice,
            NightPrice = a.NightPrice + b.NightPrice
        };
    }
}
