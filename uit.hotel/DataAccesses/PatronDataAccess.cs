using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using uit.hotel.Models;

namespace uit.hotel.DataAccesses
{
    public class PatronDataAccess : RealmDatabase
    {
        private static int NextId => Get().Count() == 0 ? 1 : Get().Max(i => i.Id) + 1;

        public static async Task<Patron> Add(Patron patron)
        {
            await Database.WriteAsync(realm =>
            {
                patron.Id = NextId;
                patron = realm.Add(patron);
            });
            return patron;
        }

        public static async Task<Patron> Update(Patron patronInDatabase, Patron patron)
        {
            await Database.WriteAsync(realm =>
            {
                patronInDatabase.Identification = patron.Identification;
                patronInDatabase.Name = patron.Name;
                patronInDatabase.Email = patron.Email;
                patronInDatabase.Gender = patron.Gender;
                patronInDatabase.Birthdate = patron.Birthdate;
                patronInDatabase.Nationality = patron.Nationality;
                patronInDatabase.Domicile = patron.Domicile;
                patronInDatabase.Residence = patron.Residence;
                patronInDatabase.Company = patron.Company;
                patronInDatabase.Note = patron.Note;
                patronInDatabase.PatronKind = patron.PatronKind;
                patronInDatabase.PhoneNumber = patron.PhoneNumber;
            });
            return patronInDatabase;
        }

        public static Patron Get(int patronId) => Database.Find<Patron>(patronId);

        public static Patron GetByIdentification(string patronIdentification) =>
            Get().Where(p => p.Identification == patronIdentification).FirstOrDefault();

        public static IEnumerable<Patron> Get() => Database.All<Patron>();
    }
}
