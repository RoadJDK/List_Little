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
                new Person
                {
                    Id = Guid.NewGuid(),
                    Number = 6,
                    FirstName = "Yann Cédric",
                    LastName = "Flückiger",
                    Street = "Untergasse 13",
                    PLZ = 2514,
                    Location = "Ligerz",
                    EMail = "yfl121149@iet-gibb.ch"
                },
                new Person
                {
                    Id = Guid.NewGuid(),
                    Number = 7,
                    FirstName = "Roman",
                    LastName = "Fäh",
                    Street = "Bürglenweg 2",
                    PLZ = 3063,
                    Location = "Ittigen",
                    EMail = "rfa121145@iet-gibb.ch"
                },
                new Person
                {
                    Id = Guid.NewGuid(),
                    Number = 8,
                    FirstName = "Rehan",
                    LastName = "Ghani",
                    Street = "Linckweg 2",
                    PLZ = 3052,
                    Location = "Zollikofen",
                    EMail = "rgh104545@iet-gibb.ch"
                },
                new Person
                {
                    Id = Guid.NewGuid(),
                    Number = 9,
                    FirstName = "Adshran",
                    LastName = "Kirubakaran",
                    Street = "Solothurnstrasse 41",
                    PLZ = 3303,
                    Location = "Jegenstorf",
                    EMail = "aki120465@iet-gibb.ch"
                },
                new Person
                {
                    Id = Guid.NewGuid(),
                    Number = 10,
                    FirstName = "Lukas",
                    LastName = "Küffer",
                    Street = "Chaletweg 15",
                    PLZ = 3174,
                    Location = "Thörishaus",
                    EMail = "lfr120333@iet-gibb.ch"
                },
                new Person
                {
                    Id = Guid.NewGuid(),
                    Number = 11,
                    FirstName = "Timo",
                    LastName = "Maibach",
                    Street = "Bäumlisacker 10",
                    PLZ = 3033,
                    Location = "Wohlen b. Bern",
                    EMail = "tma120535@iet-gibb.ch"
                },
                new Person
                {
                    Id = Guid.NewGuid(),
                    Number = 12,
                    FirstName = "Besart",
                    LastName = "Memeti",
                    Street = "Bernstrasse 28",
                    PLZ = 3175,
                    Location = "Flamatt",
                    EMail = "bme121189@iet-gibb.ch"
                },
                new Person
                {
                    Id = Guid.NewGuid(),
                    Number = 13,
                    FirstName = "Nicolas Yann",
                    LastName = "Monigadon",
                    Street = "Dorfstrasse 30",
                    PLZ = 3116,
                    Location = "Kirchdorf BE",
                    EMail = "nmo121191@iet-gibb.ch"
                },
                new Person
                {
                    Id = Guid.NewGuid(),
                    Number = 14,
                    FirstName = "Patrick",
                    LastName = "Nyffenegger",
                    Street = "Ahornweg 3",
                    PLZ = 3254,
                    Location = "Messen",
                    EMail = "pny120616@iet-gibb.ch"
                },
                new Person
                {
                    Id = Guid.NewGuid(),
                    Number = 15,
                    FirstName = "Noel",
                    LastName = "Rasiah",
                    Street = "Etzmattrain 28",
                    PLZ = 3322,
                    Location = "Urtenen-Schönbühl",
                    EMail = "nra120655@iet-gibb.ch"
                },
                new Person
                {
                    Id = Guid.NewGuid(),
                    Number = 16,
                    FirstName = "Adrian",
                    LastName = "Spycher",
                    Street = "Nord-Südstrasse 6",
                    PLZ = 4543,
                    Location = "Deitingen",
                    EMail = "asp121206@iet-gibb.ch"
                },
            };
		}
	}
}

