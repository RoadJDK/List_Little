using System;
using List_Little_Domain.Models;
using List_Little_Infrastructure_Contracts.Repositories;

namespace List_Little_Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        public IEnumerable<Person> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}

