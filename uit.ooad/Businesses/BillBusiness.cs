using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using uit.ooad.DataAccesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;

namespace uit.ooad.Businesses
{
    public class BillBusiness
    {
        public static Task<Bill> Book(Employee employee, Bill bill, List<Booking> bookings)
        {
            bill.Patron = bill.Patron.GetManaged();
            bill.Employee = employee;

            foreach (var booking in bookings)
            {
                booking.Employee = employee;
                booking.Room = booking.Room.GetManaged();
                booking.CheckValidBeforeCreate();
            }

            return BillDataAccess.Book(bill, bookings);
        }

        public static Bill Get(int billId) => BillDataAccess.Get(billId);
        public static IEnumerable<Bill> Get() => BillDataAccess.Get();
    }
}
