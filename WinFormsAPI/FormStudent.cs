using System.Windows.Forms;
using System.Text.Json;

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
            //string call = "https://dummy-json.mock.beeceptor.com/continents";
            string call = "https://dummy-json.mock.beeceptor.com/todos";
            string response = await client.GetStringAsync ( call );
            textBoxResponse.Text = response;
            List<ToDo> toDos = JsonSerializer.Deserialize<List<ToDo>>(response);
            foreach (ToDo t in toDos)
            {
                listBox1.Items.Add(t.ToString());
            }
        }
    }
}