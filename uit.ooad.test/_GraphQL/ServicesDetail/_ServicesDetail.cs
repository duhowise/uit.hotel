using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL._ServicesDetail
{
    [TestClass]
    public class _ServicesDetail
    {
        [TestMethod]
        public void ServicesDetails()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/ServicesDetail/query.servicesDetails.gql",
                @"/_GraphQL/ServicesDetail/query.servicesDetails.schema.json"
            );
        }

        [TestMethod]
        public void ServicesDetail()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/ServicesDetail/query.servicesDetail.gql",
                @"/_GraphQL/ServicesDetail/query.servicesDetail.schema.json",
                @"/_GraphQL/ServicesDetail/query.servicesDetail.variable.json"
            );
        }
    }
}
