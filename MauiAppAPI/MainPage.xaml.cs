namespace MauiAppAPI;
using StudentAPI;
using StudentAPI.DataBase;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public partial class MainPage : ContentPage
{
	int count = 0;
    private HttpClient client;
    private Community community;    

	public MainPage()
	{
		InitializeComponent();
        client = new HttpClient();
        community = new Community();
	}







	private async void BtnDownload(object sender, EventArgs e)
    {
        string call = "https://jsonplaceholder.typicode.com/users";
        string response = await client.GetStringAsync(call);

        List<ToDo> toDos = JsonSerializer.Deserialize<List<ToDo>>(response);
        var item = new List<string> { toDos[0].Headline() };
        foreach (ToDo t in toDos)
        {
            item.Add(t.ToString());
        }
        LstDeserializowany.ItemsSource = item;
        await AddToDataBase(toDos);
    }

    private async void BtnSearchById(object sender, EventArgs e)
    {
        if (!int.TryParse(TxtId.Text, out int userID) || userID <= 0)
        {
            await Application.Current.MainPage.DisplayAlert("Error","Proszę wpisać poprawne ID.","OK");
            return;
        }
        
        string call = $"https://jsonplaceholder.typicode.com/users?id={userID}";
        string response = await client.GetStringAsync(call);
        List<ToDo> toDos = JsonSerializer.Deserialize<List<ToDo>>(response);
        if (toDos.Count > 0)
        {
            var item = new List<string> { toDos[0].Headline() };
            foreach (ToDo t in toDos)
            {
                item.Add(t.ToString());
            }
            LstDeserializowany.ItemsSource = item;
        }
        else
        {
            LstDeserializowany.ItemsSource =  new List<string> {"Brak wyników dla podanego ID."};
        }
        await AddToDataBase(toDos);
    }

    private void BtnRemoveAll(object sender, EventArgs e)
    {
        community.Students.RemoveRange(community.Students);
        community.SaveChanges();
        LstDataBase.ItemsSource = community.Students.ToList<Person>();
    }

    private async void BtnAdd(object sender, EventArgs e)
    {
        FormAddStudent addStudent = new FormAddStudent(community);
        addStudent.ShowDialog();
        LstDataBase.ItemsSource = community.Students.ToList<Person>();
    }

    private async void BtnGetTop(object sender, EventArgs e)
    {
        FormAddStudentRead Read = new FormAddStudentRead();
        Read.ShowDialog();
        int prog = Read.GetLiczba();

        LstDataBase.ItemsSource = community.Students
            .Where(s => s.Id > prog)
            .ToList<Person>();
    }

    private async void BtnSort(object sender, EventArgs e)
    {
        await DisplayAlert("Informacja o sortowaniu",$"Podaj:\n1 - po Osobach\n2 - po Adresach\n3 - po Firmach","OK");
        FormAddStudentRead Read = new FormAddStudentRead();
        Read.ShowDialog();
        int Typ_Sortowania = Read.GetLiczba();
        
        switch(Typ_Sortowania)
        {
            case 1:
                LstDataBase.ItemsSource = community.Students
                .OrderBy(s => s.Id)
                .Reverse()
                .ToList<Person>();
                break;
            case 2:
                LstDataBase.ItemsSource = community.Addresses
                .OrderBy(s => s.AddressId)
                .Reverse()
                .ToList<Address>();
                break;
            case 3:
                LstDataBase.ItemsSource = community.Companies
                .OrderBy(s => s.CompanyId)
                .Reverse()
                .ToList<Company>();
                break;
            default:
            await DisplayAlert("BŁĄD, brak takiego sortowania",$"Podaj:\n1 - po Osobach\n2 - po Adresach\n3 - po Firmach","OK");
                break;
        }
    }

    private async void BtnRemove(object sender, EventArgs e)
    {
        FormAddStudentRead Read = new FormAddStudentRead();
        Read.ShowDialog();
        int IdForRemove = Read.GetLiczba();

        if(! community.Students.Any(s => s.Id == IdForRemove)) {
            await DisplayAlert("Student o podanym ID nie istnieje.", "Błąd","OK");
            return;
        }

        var student = community.Students.First(s => s.Id == IdForRemove);
        community.Students.Remove(student);
        community.SaveChanges();
        LstDataBase.ItemsSource = community.Students.ToList<Person>();
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
        LstDataBase.ItemsSource = community.Students.ToList<Person>();
    }






	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

