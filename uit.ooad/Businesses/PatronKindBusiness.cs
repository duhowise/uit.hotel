using System.Collections.Generic;
using System.Threading.Tasks;
using uit.ooad.DataAccesses;
using uit.ooad.Models;

namespace uit.ooad.Businesses
{
    public class PatronKindBusiness
    {
        public static Task<PatronKind> Add(PatronKind patronKind)
        {
            var patronKindInDatabase = PatronKindDataAccess.Get(patronKind.Id);
            if (patronKindInDatabase != null) return null;

            return PatronKindDataAccess.Add(patronKind);
        }
        public static PatronKind Get(int patronKindId) => PatronKindDataAccess.Get(patronKindId);
        public static IEnumerable<PatronKind> Get() => PatronKindDataAccess.Get();
    }
}
