using System;
using System.Collections.Generic;
using System.Linq;
using Realms;
using uit.hotel.Businesses;

namespace uit.hotel.Models
{
    public class Patron : RealmObject
    {
        [Indexed]
        [PrimaryKey]
        public int Id { get; set; }
        // Định danh: Số an sinh xã hội / Số chứng minh nhân dân / Số passport
        public string Identification { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Gender { get; set; }
        public DateTimeOffset Birthdate { get; set; }
        public string PhoneNumber { get; set; }
        public string Nationality { get; set; } // Quốc tịch
        public string Domicile { get; set; } // Nguyên quán
        public string Residence { get; set; } // Thường trú
        public string Company { get; set; }
        public string Note { get; set; }
        public PatronKind PatronKind { get; set; }

        [Backlink(nameof(Bill.Patron))]
        public IQueryable<Bill> Bills { get; }

        [Backlink(nameof(Booking.Patrons))]
        public IQueryable<Booking> Bookings { get; }

        public Patron GetManaged()
        {
            var patronInDatabase = PatronBusiness.Get(Id);
            if (patronInDatabase == null)
                throw new Exception("Mã khách hàng không tồn tại");
            return patronInDatabase;
        }
    }
}
