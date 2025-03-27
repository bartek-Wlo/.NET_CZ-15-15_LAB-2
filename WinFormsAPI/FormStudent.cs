using System.Windows.Forms;
using System.Text.Json;
/* https://jsonplaceholder.typicode.com/ */

namespace StudentAPI
{
    public partial class FormStudent : Form
    {
        private HttpClient client;
        public FormStudent()
        {
            InitializeComponent();
            client = new HttpClient();
        }
        private async void buttonDownload_ClickAsync ( object sender, EventArgs e)
        {
            int userID = 2;
            // string call = "https://dummy-json.mock.beeceptor.com/continents";
            // string call = "https://dummy-json.mock.beeceptor.com/todos";
            string call = "https://jsonplaceholder.typicode.com/users";
            // string call = $"https://jsonplaceholder.typicode.com/users?id={userID}";
            string response = await client.GetStringAsync ( call );
            textBoxResponse.Text = response;
            List<ToDo> toDos = JsonSerializer.Deserialize<List<ToDo>>(response);
            listBox1.Items.Add(toDos[0].Headline());
            listBox1.Items.Clear();
            foreach (ToDo t in toDos)
            {
                listBox1.Items.Add(t.ToString());
            }
        }


        private async void buttonyId_ClickAsync(object sender, EventArgs e)
        {
            if (!int.TryParse(textId.Text, out int userID) || userID <= 0)
            {
                MessageBox.Show("Proszę wpisać poprawne ID.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            string call = $"https://jsonplaceholder.typicode.com/users?id={userID}";
            string response = await client.GetStringAsync(call);
            textBoxResponse.Text = response;
            List<ToDo> toDos = JsonSerializer.Deserialize<List<ToDo>>(response);
            listBox1.Items.Clear();
            if (toDos.Count > 0)
            {
                listBox1.Items.Add(toDos[0].Headline());
                foreach (ToDo t in toDos)
                {
                    listBox1.Items.Add(t.ToString());
                }
            }
            else
            {
                listBox1.Items.Add("Brak wyników dla podanego ID.");
            }
        }
    }
}