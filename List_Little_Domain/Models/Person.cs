﻿using System;
namespace List_Little_Domain.Models
{
	public class Person
	{
        Guid Id { get; set; }
        int Number { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Street { get; set; }
        int PLZ { get; set; }
        string Location { get; set; }
        string EMail { get; set; }
    }
}
