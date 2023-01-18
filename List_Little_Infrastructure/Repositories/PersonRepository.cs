using System;
using List_Little_Domain.Models;
using List_Little_Infrastructure.Database;
using List_Little_Infrastructure_Contracts.Repositories;

namespace List_Little_Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DataContext Db;

        public PersonRepository(DataContext db)
        {
            Db = db;
        }

        public IEnumerable<Person> GetAll()
        {
            try
            {
                return Db.Persons.AsQueryable<Person>();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
