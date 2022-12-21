namespace List_Little_Api.DTOs
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
        FileStream Image { get; set; }
    }
}

