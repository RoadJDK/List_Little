using System;
using List_Little_Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace List_Little_Infrastructure.Database.Seeding
{
	public static class DbSeeder
	{
		public static void SeedDatabase(ModelBuilder modelbuilder)
		{
			var personList = FillPersonList().ToList();

            modelbuilder.Entity<Person>().HasData(personList);
		}

		private static IEnumerable<Person> FillPersonList()
		{
			return new List<Person>
			{
				new Person
				{
					Id = Guid.NewGuid(),
					Number = 1,
					FirstName = "Linus",
					LastName = "Ackermann",
					Street = "Wiesenstrasse 54",
					PLZ = 3014,
					Location = "Bern",
					EMail = "lac121115@iet-gibb.ch"
				},
                new Person
                {
                    Id = Guid.NewGuid(),
                    Number = 2,
                    FirstName = "Aline",
                    LastName = "Ammann",
                    Street = "Brüggeweidlistrasse 8",
                    PLZ = 3718,
                    Location = "Kandersteg",
                    EMail = "aam120166@iet-gibb.ch"
                },
                new Person
                {
                    Id = Guid.NewGuid(),
                    Number = 3,
                    FirstName = "Joel",
                    LastName = "Blaser",
                    Street = "Fröschenmoosweg 51",
                    PLZ = 3713,
                    Location = "Reichenbach im Kandertal",
                    EMail = "jbl121127@iet-gibb.ch"
                },
                new Person
                {
                    Id = Guid.NewGuid(),
                    Number = 4,
                    FirstName = "Marc",
                    LastName = "Büetiger",
                    Street = "Bruggbühlstrasse 33",
                    PLZ = 3172,
                    Location = "Niederwangen b. Bern",
                    EMail = "mbu107692@iet-gibb.ch"
                },
                new Person
                {
                    Id = Guid.NewGuid(),
                    Number = 5,
                    FirstName = "Justin",
                    LastName = "Ceronio",
                    Street = "Chrützweg 19",
                    PLZ = 3707,
                    Location = "Därligen",
                    EMail = "jce121133@iet-gibb.ch"
                },
            };
		}
	}
}

