using System.Linq;
using GraphQL.Types;
using uit.ooad.Models;

namespace uit.ooad.ObjectTypes
{
    public class BookingType : ObjectGraphType<Booking>
    {
        public BookingType()
        {
            Name = nameof(Booking);
            Description = "Một thông tin thuê phòng của khách hàng";

            Field(x => x.Id).Description("Id của thông tin thuê phòng");
            Field(x => x.CheckInTime).Description("Thời điểm nhận phòng dự kiến của khách hàng");
            Field(x => x.CheckOutTime).Description("Thời điểm trả phòng dự kiến của khách hàng");
            Field(x => x.CreateTime).Description("Thời điểm tạo thông tin thuê phòng");
            Field(x => x.Status).Description("Trạng thái của thông tin thuê phòng");

            Field<EmployeeType>(nameof(Booking.Employee), resolve: context => context.Source.Employee,
                                description: "Nhân viên thực hiện giao dịch nhận đặt phòng từ khách hàng");
            Field<BillType>(nameof(Booking.Bill), resolve: context => context.Source.Bill,
                            description: "Thông tin hóa đơn của thông tin thuê phòng");
            Field<RoomType>(nameof(Booking.Room), resolve: context => context.Source.Room,
                            description: "Phòng khách hàng chọn đặt trước");

            Field<ListGraphType<PatronType>>(
                nameof(Booking.Patrons),
                resolve: context => context.Source.Patrons.ToList(),
                description: "Danh sách khách hàng yêu cầu đặt phòng"
            );

            Field<ListGraphType<HouseKeepingType>>(
                nameof(Booking.HouseKeepings),
                resolve: context => context.Source.HouseKeepings.ToList(),
                description: "Danh sách nhân viên dọn phòng cho phòng đã đặt này"
            );

            Field<ListGraphType<ServicesDetailType>>(
                nameof(Booking.ServicesDetails),
                resolve: context => context.Source.ServicesDetails.ToList(),
                description: "Danh sách chi tiết sử dụng dịch vụ của khách hàng"
            );
        }
    }
}