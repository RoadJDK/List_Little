namespace List_Little_Domain.Models
{
	public class Person
	{
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public int PLZ { get; set; }
        public string Location { get; set; }
        public string EMail { get; set; }
    }
}
