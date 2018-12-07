using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Base;

public class HouseKeepingQuery : QueryType<HouseKeeping>
{
    public HouseKeepingQuery()
    {
        Field<ListGraphType<HouseKeepingType>>(
            _List,
            "Trả về một danh sách các công việc dọn dẹp",
            resolve: context => HouseKeepingBusiness.Get()
        );
        Field<HouseKeepingType>(
            _Item,
            "Trả về thông tin một công việc dọn dẹp",
            IdArgument(),
            context => HouseKeepingBusiness.Get(GetId<int>(context))
        );
    }
}