namespace StudentAPI
{
    public class Geo
    {
        public required string lat { get; set; }
        public required string lng { get; set; }
    }

    public class Address
    {
        public int AddressId { get; set; }
        public required string street { get; set; }
        public required string suite { get; set; }
        public required string city { get; set; }
        public string? zipcode { get; set; }
        public Geo? geo { get; set; }
    }

    public class Company
    {
        public int CompanyId {get;set;}
        public required string name { get; set; }
        public string? catchPhrase { get; set; }
        public string? bs { get; set; }
    }
}