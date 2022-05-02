using Dapper;
using Esperanza.Core.Interfaces.DataAccess;
using Esperanza.Core.Models;
using Esperanza.Repository.Constants;
using System.Data;

namespace Esperanza.Repository.DataAccess
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        private readonly IConnectionBuilder ConnectionBuilder;

        public PersonRepository(
            IConnectionBuilder connectionBuilder
            ) : base(Table.Person, connectionBuilder)
        {
            ConnectionBuilder = connectionBuilder;
        }

        public async Task<Person> GetFullPerson(Guid personGuid)
        {
            Person person;
            using (IDbConnection db = ConnectionBuilder.GetConnection())
            {
                person = (await db.QueryAsync<Person, Sex, DocumentType, Phone, Person>(
                    Person.GetByGuid, (person, sex, document, phone) =>
                    {
                        person.Sex = sex;
                        person.DocumentType = document;
                        person.Phone = phone;
                        return person;
                    }, new { Guid = personGuid }, splitOn: "Guid,Guid,Guid")).FirstOrDefault();
            }
            return person;
        }
    }
}
