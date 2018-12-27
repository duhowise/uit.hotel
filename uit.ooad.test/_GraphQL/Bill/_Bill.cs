using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL._Bill
{
    [TestClass]
    public class _Bill
    {
        [TestMethod]
        public void Bills()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Bill/query.bills.gql",
                @"/_GraphQL/Bill/query.bills.schema.json"
            );
        }

        [TestMethod]
        public void Bill()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Bill/query.bill.gql",
                @"/_GraphQL/Bill/query.bill.schema.json",
                @"/_GraphQL/Bill/query.bill.variable.json"
            );
        }

        // [TestMethod]
        // public void CreateBill()
        // {
        //     SchemaHelper.Execute(
        //         @"/_GraphQL/Bill/mutation.createBill.gql",
        //         @"/_GraphQL/Bill/mutation.createBill.schema.json",
        //         @"/_GraphQL/Bill/mutation.createBill.variable.json",
        //         p => p.PermissionManageHiringRooms = true
        //     );
        // }
    }
}
