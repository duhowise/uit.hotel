using Microsoft.VisualStudio.TestTools.UnitTesting;
using uit.ooad.Businesses;
using uit.ooad.Models;
using uit.ooad.test.Helper;

namespace uit.ooad.test._GraphQL._Room
{
    [TestClass]
    public class _Room
    {
        [TestMethod]
        public void Rooms()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Room/query.rooms.gql",
                @"/_GraphQL/Room/query.rooms.schema.json"
            );
        }
        [TestMethod]
        public void Room()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Room/query.room.gql",
                @"/_GraphQL/Room/query.room.schema.json",
                @"/_GraphQL/Room/query.room.variable.json"
            );
        }
        [TestMethod]
        public void CreateRoom()
        {
            SchemaHelper.Execute(
                @"/_GraphQL/Room/mutation.createRoom.gql",
                @"/_GraphQL/Room/mutation.createRoom.schema.json",
                @"/_GraphQL/Room/mutation.createRoom.variable.json",
                p => p.PermissionCreateOrUpdateRoom = true
            );
        }
    }
}
