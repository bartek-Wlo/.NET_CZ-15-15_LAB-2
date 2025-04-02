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

        public override string ToString() {
            return $"{AddressId+",",-5}{street+",",-25}\t{suite+",",-5}\t{city+",",-30}\t{geo?.lat+",",-20}\t{geo?.lng}";
        }
    }

    public class Company
    {
        public int CompanyId {get;set;}
        public required string name { get; set; }
        public string? catchPhrase { get; set; }
        public string? bs { get; set; }
     
        public override string ToString() {
            return $"{CompanyId+",",-5}{name+",",-25}\t{catchPhrase+",",-50}\t{bs}";
    }
    }
}