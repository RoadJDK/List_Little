using System;
using List_Little_Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace List_Little_Infrastructure.Database
{
	public class DataContext : DbContext
	{
		DbSet<Person> Persons { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

		}
    }
}

