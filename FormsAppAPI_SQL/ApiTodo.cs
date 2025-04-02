namespace StudentAPI
{
    internal class ToDo
    {   
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public Address address { get; set; }
        public string phone { get; set; }
        public string website { get; set; }
        public Company company { get; set; }

        public string Headline() {
        return $"Id   Name\t\t\tUserName\t\tEmail\t\t\t\tCity\t\t\tCompany";
        }
        public override string ToString() {
        return $"{id+",",-5}{name+",",-25}\t{username+",",-20}\t{email+",",-30}\t{address?.city+",",-20}\t{company?.name}";
        }
    }
}