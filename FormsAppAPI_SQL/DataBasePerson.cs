namespace StudentAPI.DataBase
{
    internal class Person
    {   
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required int AddressId { get; set; }
        public Address? Address { get; set; }
        public string? Phone { get; set; }
        public string? Website { get; set; }
        public required int CompanyId { get; set; }
        public Company? Company { get; set; }

        public string Headline() {
            return $"Id   Name\t\t\tUserName\t\tEmail\t\t\t\tCity\t\t\tCompany";
        }
        public override string ToString() {
            return $"{Id+",",-5}{Name+",",-25}\t{Username+",",-20}\t{Email+",",-30}\t{Address?.city+",",-20}\t{Company?.name}";
        }
    }
}