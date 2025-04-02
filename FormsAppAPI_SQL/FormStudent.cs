using System.Windows.Forms;
using System.Text.Json;
using StudentAPI.DataBase;
using Microsoft.EntityFrameworkCore;
/* https://jsonplaceholder.typicode.com/ */

using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("MauiAppAPI")]

namespace StudentAPI
{
    public partial class FormStudent : Form
    {
        private HttpClient client;
        private Community community;
        public FormStudent()
        {
            InitializeComponent();
            client = new HttpClient();
            community = new Community();
        }
        
        /*\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾L*/
        /*/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\  DOWNLAND \_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/*/
        private async void buttonDownload_ClickAsync(object sender, EventArgs e)
        {
            string call = "https://jsonplaceholder.typicode.com/users";
            string response = await client.GetStringAsync(call);
            listResponse.Text = response;
            List<ToDo> toDos = JsonSerializer.Deserialize<List<ToDo>>(response);
            listDeserializowany.Items.Clear();
            listDeserializowany.Items.Add(toDos[0].Headline());
            foreach (ToDo t in toDos)
            {
                listDeserializowany.Items.Add(t.ToString());
            }
            await AddToDataBase(toDos);
        }


        /*\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾L*/
        /*/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/  downland ID  /‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/*/
        private async void buttonyId_ClickAsync(object sender, EventArgs e)
        {
            if (!int.TryParse(textId.Text, out int userID) || userID <= 0)
            {
                MessageBox.Show("Proszę wpisać poprawne ID.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            string call = $"https://jsonplaceholder.typicode.com/users?id={userID}";
            string response = await client.GetStringAsync(call);
            listResponse.Text = response;
            List<ToDo> toDos = JsonSerializer.Deserialize<List<ToDo>>(response);
            listDeserializowany.Items.Clear();
            if (toDos.Count > 0)
            {
                listDeserializowany.Items.Add(toDos[0].Headline());
                foreach (ToDo t in toDos)
                {
                    listDeserializowany.Items.Add(t.ToString());
                }
            }
            else
            {
                listDeserializowany.Items.Add("Brak wyników dla podanego ID.");
            }
            await AddToDataBase(toDos);
        }



        /*\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾L*/
        /*/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\   ZNAJDZ  \_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/*/
        private void buttonGetTop_Click(object sender, EventArgs e)
        {
            FormAddStudentRead Read = new FormAddStudentRead();
            Read.ShowDialog();
            int prog = Read.GetLiczba();

            listDataBase.DataSource = community.Students
                .Where(s => s.Id > prog)
                .ToList<Person>();
        }

        /*\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾L*/
        /*/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\  SORTUJ   \_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/*/
        private void buttonSort_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Podaj:\n1 - po Osobach\n2 - po Adresach\n3 - po Firmach", "Informacja o sortowaniu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FormAddStudentRead Read = new FormAddStudentRead();
            Read.ShowDialog();
            int Typ_Sortowania = Read.GetLiczba();
            
            switch(Typ_Sortowania)
            {
                case 1:
                    listDataBase.DataSource = community.Students
                    .OrderBy(s => s.Id)
                    .Reverse()
                    .ToList<Person>();
                    break;
                case 2:
                    listDataBase.DataSource = community.Addresses
                    .OrderBy(s => s.AddressId)
                    .Reverse()
                    .ToList<Address>();
                    break;
                case 3:
                    listDataBase.DataSource = community.Companies
                    .OrderBy(s => s.CompanyId)
                    .Reverse()
                    .ToList<Company>();
                    break;
                default:
                MessageBox.Show($"Podaj:\n1 - po Osobach\n2 - po Adresach\n3 - po Firmach", "BŁĄD, brak takiego sortowania", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        /*\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾L*/
        /*/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\  REMOVE   \_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/*/
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            FormAddStudentRead Read = new FormAddStudentRead();
            Read.ShowDialog();
            int IdForRemove = Read.GetLiczba();

            if(! community.Students.Any(s => s.Id == IdForRemove)) {
                MessageBox.Show("Student o podanym ID nie istnieje.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var student = community.Students.First(s => s.Id == IdForRemove);
            community.Students.Remove(student);
            community.SaveChanges();
            listDataBase.DataSource = community.Students.ToList<Person>();
        }

        /*\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾L*/
        /*/‾\_/‾\_/‾\_/‾\_/‾\_/‾\ USUŃ  WSZYSTKIE  REKODRDY \_/‾\_/‾\_/‾\_/‾\_/‾\_/*/
        private void buttonRemoveAll_Click(object sender, EventArgs e)
        {
            community.Students.RemoveRange(community.Students);
            community.SaveChanges();
            listDataBase.DataSource = community.Students.ToList<Person>();
        }



        /*\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾L*/
        /*/‾\_/‾\_/‾\_/‾\_/‾\_/‾\      DODAJ nowe dane      \_/‾\_/‾\_/‾\_/‾\_/‾\_/*/
        private void buttonAdd_Click(object sender, System.EventArgs e)
        {
            FormAddStudent addStudent = new FormAddStudent(community);
            addStudent.ShowDialog();
            listDataBase.DataSource = community.Students.ToList<Person>();
        }




        /*\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾L*/
        /*/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\ ADD  data \_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/‾\_/*/
        private async Task AddToDataBase(List<ToDo> ListToDo) {
            foreach(ToDo TD in ListToDo) {
                if( !await community.Students.AnyAsync(p => p.Id == TD.id)) {
                    community.Students.Add(new Person() {
                        Id = TD.id,
                        Name = TD.name,
                        Username = TD.username,
                        Email = TD.email,
                        AddressId = TD.id,
                        CompanyId = TD.id,
                        Phone = TD.phone,
                        Website = TD.website
                    });
                }
                if( !await community.Addresses.AnyAsync(p => p.AddressId == TD.id)) {
                    Geo newGeo = new Geo {lat = TD.address.geo.lat, lng = TD.address.geo.lng};
                    community.Addresses.Add(new Address() {
                        AddressId = TD.id, 
                        street = TD.address.street,
                        suite = TD.address.suite,
                        city = TD.address.city,
                        zipcode = TD.address.zipcode,
                        geo = newGeo
                    });
                }
                if( !await community.Companies.AnyAsync(p => p.CompanyId == TD.id)) {
                    community.Companies.Add(new Company() {
                        CompanyId = TD.id, 
                        name = TD.company.name,
                        bs = TD.company.bs,
                        catchPhrase = TD.company.catchPhrase
                    });
                }
            }
            community.SaveChanges();
            listDataBase.DataSource = community.Students.ToList<Person>();
        }
    }
}