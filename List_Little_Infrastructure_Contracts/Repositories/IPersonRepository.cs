using System;
using List_Little_Domain.Models;

namespace List_Little_Infrastructure_Contracts.Repositories
{
	public interface IPersonRepository
	{
		public IEnumerable<Person> GetAll();
	}
}

