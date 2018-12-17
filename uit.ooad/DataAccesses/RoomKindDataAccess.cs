using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uit.ooad.Models;

namespace uit.ooad.DataAccesses
{
    public class RoomKindDataAccess : RealmDatabase
    {
        public static async Task<RoomKind> Add(RoomKind roomKind)
        {
            await Database.WriteAsync(realm =>
            {
                roomKind.Id = Get().Count() == 0 ? 1 : Get().Max(f => f.Id) + 1;

                roomKind = realm.Add(roomKind);
            });
            return roomKind;
        }

        public static RoomKind Get(int roomKindId) => Database.Find<RoomKind>(roomKindId);
        public static IEnumerable<RoomKind> Get() => Database.All<RoomKind>();
    }
}
