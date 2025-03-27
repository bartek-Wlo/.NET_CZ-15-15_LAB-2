namespace StudentAPI
{
    internal class ToDo
    {   /*
        public int userId { get ; set ; }
        public int id { get ; set ; }
        public string title { get ; set ; }
        public bool completed { get ; set ; }

        public override string ToString ()
        {
        return $"User Id: {userId},\tId: {id+",",-5}\tTitle: {title+",",-20}\tCompleted: {completed}";
        }   */
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





    public class Geo
    {
        public string lat { get; set; }
        public string lng { get; set; }
    }

    public class Address
    {
        public string street { get; set; }
        public string suite { get; set; }
        public string city { get; set; }
        public string zipcode { get; set; }
        public Geo geo { get; set; }
    }

    public class Company
    {
        public string name { get; set; }
        public string catchPhrase { get; set; }
        public string bs { get; set; }
    }
}