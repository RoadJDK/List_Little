using System;
using List_Little_Business_Contracts.Services;
using List_Little_Domain.Models;
using List_Little_Infrastructure_Contracts.Repositories;

namespace List_Little_Business.Services
{
    public class PersonService : IPersonService
    {
        public readonly IPersonRepository Repository;

        public PersonService(IPersonRepository repository)
        {
            Repository = repository;
        }

        public IEnumerable<Person> GetAll()
        {
            return Repository.GetAll();
        }
    }
}

