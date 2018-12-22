using System.Collections.Generic;
using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Authentication;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Mutation
{
    public class BookingMutation : QueryType<Booking>
    {
        public BookingMutation()
        {
            Field<BookingType>(
                "CheckIn",
                "Cập nhật thời gian checkin của phòng",
                _IdArgument(),
                _CheckPermission(
                    person => person.PermissionCreateBooking,
                    context => BookingBusiness.CheckIn(_GetId<int>(context))
                )
            );
        }
    }
}
