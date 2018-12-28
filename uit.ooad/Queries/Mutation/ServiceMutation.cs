using GraphQL.Types;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries.Base;

namespace uit.ooad.Queries.Mutation
{
    public class ServiceMutation : QueryType<Service>
    {
        public ServiceMutation()
        {
            Field<ServiceType>(
                _Creation,
                "Tạo và trả về một dịch vụ mới",
                _InputArgument<ServiceCreateInput>(),
                _CheckPermission_Object(
                    p => p.PermissionCreateOrUpdateService,
                    context => ServiceBusiness.Add(_GetInput(context))
                )
            );

            Field<ServiceType>(
                _Updation,
                "Cập nhật và trả về một dịch vụ mới cập nhật",
                _InputArgument<ServiceUpdateInput>(),
                _CheckPermission_Object(
                    p => p.PermissionCreateOrUpdateService,
                    context => ServiceBusiness.Update(_GetInput(context))
                )
            );

            Field<StringGraphType>(
                "SetIsActiveService",
                "Cập nhật trạng thái của dịch vụ",
                new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" },
                    new QueryArgument<NonNullGraphType<BooleanGraphType>> { Name = "isActive" }
                ),
                context =>
                {
                    var serviceId = context.GetArgument<int>("id");
                    var isActive = context.GetArgument<bool>("isActive");

                    ServiceBusiness.SetIsActive(serviceId, isActive);
                    return "Thành công";
                }
            );
        }
    }
}