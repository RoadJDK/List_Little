using System;
using List_Little_Domain.Models;

namespace List_Little_Business_Contracts.Services
{
	public interface IPersonService
	{
		public IEnumerable<Person> GetAll();
	}
}

