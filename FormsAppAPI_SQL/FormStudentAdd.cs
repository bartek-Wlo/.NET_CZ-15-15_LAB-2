using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using StudentAPI.DataBase;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace StudentAPI
{
    public partial class FormAddStudent : Form
    {
        private Community community;
        // ---- Publiczna właściwość do przekazania gotowego obiektu ----
        // public Person NewPersonData { get; private set; } = null; // Inicjalizujemy na null

        private Label labelStudentHeader;
        private Label labelStudentName;
        private TextBox textStudentName;
        private Label labelUsername;
        private TextBox textUsername;
        private Label labelEmail;
        private TextBox textEmail;
        private Label labelPhone;
        private TextBox textPhone;
        private Label labelWebsite;
        private TextBox textWebsite;

        private Label labelAddressHeader;
        private Label labelStreet;
        private TextBox textStreet;
        private Label labelSuite;
        private TextBox textSuite;
        private Label labelCity;
        private TextBox textCity;
        private Label labelZipcode;
        private TextBox textZipcode;

        private Label labelLatitude;
        private TextBox textLatitude;
        private Label labelLongitude;
        private TextBox textLongitude;
        
        private Label labelCompanyHeader;
        private Label labelCompanyName;
        private TextBox textCompanyName;
        private Label labelCatchPhrase;
        private TextBox textCatchPhrase;
        private Label labelBs;
        private TextBox textBs;
        private Button buttonOk;
        
        private Button buttonCancel;
        private IContainer components = null;

        internal FormAddStudent(Community communityFromStudents)
        {
            if (communityFromStudents == null) throw new ArgumentNullException(nameof(communityFromStudents));
            this.community = communityFromStudents;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            int Height = 20;
            int labelWidth = 80;
            int textBoxWidth = 280;
            int yPos = 10;
            int xLabel = 15;
            int xTextBox = xLabel + labelWidth + 5;
            int spacing = Height + 10;

            this.labelStudentHeader = new Label();
            this.labelStudentName = new Label();
            this.textStudentName = new TextBox();
            this.labelUsername = new Label();
            this.textUsername = new TextBox();
            this.labelEmail = new Label();
            this.textEmail = new TextBox();
            this.labelPhone = new Label();
            this.textPhone = new TextBox();
            this.labelWebsite = new Label();
            this.textWebsite = new TextBox();

            this.labelAddressHeader = new Label();
            this.labelStreet = new Label();
            this.textStreet = new TextBox();
            this.labelSuite = new Label();
            this.textSuite = new TextBox();
            this.labelCity = new Label();
            this.textCity = new TextBox();
            this.labelZipcode = new Label();
            this.textZipcode = new TextBox();

            this.labelLatitude = new Label();
            this.textLatitude = new TextBox();
            this.labelLongitude = new Label();
            this.textLongitude = new TextBox();

            this.labelCompanyHeader = new Label();
            this.labelCompanyName = new Label();
            this.textCompanyName = new TextBox();
            this.labelCatchPhrase = new Label();
            this.textCatchPhrase = new TextBox();
            this.labelBs = new Label();
            this.textBs = new TextBox();

            this.buttonOk = new Button();
            this.buttonCancel = new Button();

            this.SuspendLayout();

            ConfigureHeader(labelStudentHeader, "Dane Studenta", ref yPos);
            ConfigureLabel(labelStudentName, "Imię Naz.:", xLabel, yPos, labelWidth, Height);
            ConfigureTextBox(textStudentName, xTextBox, yPos, textBoxWidth, 1);
            yPos += spacing;
            ConfigureLabel(labelUsername, "Nazwa uż.:", xLabel, yPos, labelWidth, Height);
            ConfigureTextBox(textUsername, xTextBox, yPos, textBoxWidth, 2);
            yPos += spacing;
            ConfigureLabel(labelEmail, "Email:", xLabel, yPos, labelWidth, Height);
            ConfigureTextBox(textEmail, xTextBox, yPos, textBoxWidth, 3);
            yPos += spacing;
            ConfigureLabel(labelPhone, "Telefon:", xLabel, yPos, labelWidth, Height);
            ConfigureTextBox(textPhone, xTextBox, yPos, textBoxWidth, 4);
            yPos += spacing;
            ConfigureLabel(labelWebsite, "Strona WWW:", xLabel, yPos, labelWidth, Height);
            ConfigureTextBox(textWebsite, xTextBox, yPos, textBoxWidth, 5);
            yPos += spacing + 10;

            ConfigureHeader(labelAddressHeader, "Adres", ref yPos);
            ConfigureLabel(labelStreet, "Ulica:", xLabel, yPos, labelWidth, Height);
            ConfigureTextBox(textStreet, xTextBox, yPos, textBoxWidth, 6);
            yPos += spacing;
            ConfigureLabel(labelSuite, "Nr lokalu:", xLabel, yPos, labelWidth, Height);
            ConfigureTextBox(textSuite, xTextBox, yPos, textBoxWidth, 7);
            yPos += spacing;
            ConfigureLabel(labelCity, "Miasto:", xLabel, yPos, labelWidth, Height);
            ConfigureTextBox(textCity, xTextBox, yPos, textBoxWidth, 8);
            yPos += spacing;
            ConfigureLabel(labelZipcode, "Kod poczt.:", xLabel, yPos, labelWidth, Height);
            ConfigureTextBox(textZipcode, xTextBox, yPos, textBoxWidth, 9);
            yPos += spacing;
        
            ConfigureLabel(labelLatitude, "Szerokość geo.:", xLabel, yPos, labelWidth, Height);
            ConfigureTextBox(textLatitude, xTextBox, yPos, textBoxWidth, 10);
            yPos += spacing;
            ConfigureLabel(labelLongitude, "Długość geo.:", xLabel, yPos, labelWidth, Height);
            ConfigureTextBox(textLongitude, xTextBox, yPos, textBoxWidth, 11);
            yPos += spacing + 10;

            ConfigureHeader(labelCompanyHeader, "Firma", ref yPos);
            ConfigureLabel(labelCompanyName, "Nazwa firmy:", xLabel, yPos, labelWidth, Height);
            ConfigureTextBox(textCompanyName, xTextBox, yPos, textBoxWidth, 12);
            yPos += spacing;
            ConfigureLabel(labelCatchPhrase, "Slogan:", xLabel, yPos, labelWidth, Height);
            ConfigureTextBox(textCatchPhrase, xTextBox, yPos, textBoxWidth, 13);
            yPos += spacing;
            ConfigureLabel(labelBs, "BS:", xLabel, yPos, labelWidth, Height);
            ConfigureTextBox(textBs, xTextBox, yPos, textBoxWidth, 14);
            yPos += spacing + 20;

            this.buttonOk.Location = new Point(xTextBox + textBoxWidth - 160, yPos);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new Size(75, 30);
            this.buttonOk.TabIndex = 15;
            this.buttonOk.Text = "Dodaj";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new EventHandler(this.buttonOk_Click);

            this.buttonCancel.DialogResult = DialogResult.Cancel;
            this.buttonCancel.Location = new Point(xTextBox + textBoxWidth - 75, yPos);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new Size(75, 30);
            this.buttonCancel.TabIndex = 16;
            this.buttonCancel.Text = "Anuluj";
            this.buttonCancel.UseVisualStyleBackColor = true;

            this.AcceptButton = this.buttonOk;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new Size(xTextBox + textBoxWidth + xLabel, yPos + 40);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddStudent";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Dodaj nowe dane do tabeli";

            this.Controls.Add(this.labelStudentHeader);
            this.Controls.Add(this.labelStudentName); this.Controls.Add(this.textStudentName);
            this.Controls.Add(this.labelUsername);    this.Controls.Add(this.textUsername);
            this.Controls.Add(this.labelEmail);       this.Controls.Add(this.textEmail);
            this.Controls.Add(this.labelPhone);       this.Controls.Add(this.textPhone);
            this.Controls.Add(this.labelWebsite);     this.Controls.Add(this.textWebsite);
            
            this.Controls.Add(this.labelAddressHeader);
            this.Controls.Add(this.labelStreet);      this.Controls.Add(this.textStreet);
            this.Controls.Add(this.labelSuite);       this.Controls.Add(this.textSuite);
            this.Controls.Add(this.labelCity);        this.Controls.Add(this.textCity);
            this.Controls.Add(this.labelZipcode);     this.Controls.Add(this.textZipcode);

            this.Controls.Add(this.labelLatitude);    this.Controls.Add(this.textLatitude);
            this.Controls.Add(this.labelLongitude);   this.Controls.Add(this.textLongitude);

            this.Controls.Add(this.labelCompanyHeader);
            this.Controls.Add(this.labelCompanyName); this.Controls.Add(this.textCompanyName);
            this.Controls.Add(this.labelCatchPhrase); this.Controls.Add(this.textCatchPhrase);
            this.Controls.Add(this.labelBs);          this.Controls.Add(this.textBs);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonCancel);

            this.ResumeLayout(false);
            this.PerformLayout();
        }
















        // --- Metody pomocnicze do konfiguracji kontrolek ---
        private void ConfigureLabel(Label lbl, string text, int x, int y, int width, int height) { 
            lbl.AutoSize = false; 
            lbl.Location = new Point(x, y + 3); 
            lbl.Name = "label" + text.Replace(":", "").Replace(" ", "").Replace("/", ""); 
            lbl.Size = new Size(width, height); 
            lbl.TabIndex = 0; lbl.Text = text; 
            lbl.TextAlign = ContentAlignment.MiddleRight;
        }
        private void ConfigureTextBox(TextBox txt, int x, int y, int width, int tabIndex) {
            txt.Location = new Point(x, y); 
            txt.Name = "text" + tabIndex; 
            txt.Size = new Size(width, 20); 
            txt.TabIndex = tabIndex;
        }
        private void ConfigureHeader(Label lbl, string text, ref int yPos) {
            lbl.AutoSize = true;
            lbl.Font = new Font(this.Font, FontStyle.Bold);
            lbl.Location = new Point(15, yPos);
            lbl.Name = "labelHeader" + text.Replace(" ", "");
            lbl.TabIndex = 0;
            lbl.Text = text;
            yPos += 25;
        }

















        
        private async void buttonOk_Click(object sender, EventArgs e) {
            if (!ValidateInput()) return; /* Jeżeli nie podano wszystkich parametrów */

            try {
                Geo newGeo = new Geo {lat = textLatitude.Text, lng = textLongitude.Text};
                community.Addresses.Add(new Address() { 
                    street = textStreet.Text,
                    suite = textSuite.Text,
                    city = textCity.Text,
                    zipcode = textZipcode.Text,
                    geo = newGeo
                });
            
            
                community.Companies.Add(new Company() {
                    name = textCompanyName.Text, 
                    bs = textBs.Text,
                    catchPhrase = textCatchPhrase.Text
                });
                community.SaveChanges(); // BARDZO WAŻNE

                int? Address_ID = await community.Addresses.Where(a => a.street == textStreet.Text)
                                                          .Select(a => a.AddressId)
                                                          .FirstOrDefaultAsync();
                int? Company_ID = await community.Companies.Where(c => c.name == textCompanyName.Text)
                                                          .Select(c => c.CompanyId)
                                                          .FirstOrDefaultAsync();
                if(Address_ID.HasValue && Company_ID.HasValue) {
                    community.Students.Add(new Person() {
                    Name = textStudentName.Text,
                    Username = textUsername.Text,
                    Email = textEmail.Text,
                    AddressId = Address_ID.Value,
                    CompanyId = Company_ID.Value,
                    Phone = textPhone.Text,
                    Website = textWebsite.Text
                });
                } else throw new InvalidOperationException("FormAddStudent -> buttonOk_Click -> Address or Company ID wrong.");
                community.SaveChanges();
                this.DialogResult = DialogResult.OK;
                this.Close(); /* Zamyka okno */
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Message: {ex.Message}");
                Console.WriteLine($"\nOuter Exception Stack Trace:\n{ex.StackTrace}"); // Gdzie EF zgłosił błąd
                MessageBox.Show($"Wystąpił błąd podczas przygotowywania danych: {ex.Message}", "Błąd wewnętrzny", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
        }
















        private bool ValidateInput() {
            if (string.IsNullOrWhiteSpace(textStudentName.Text)) return ShowValidationError("Pole 'Imię/Nazwisko' studenta jest wymagane.", textStudentName);
            if (string.IsNullOrWhiteSpace(textUsername.Text))    return ShowValidationError("Pole 'Nazwa użytkownika' jest wymagane.", textUsername);
            if (string.IsNullOrWhiteSpace(textEmail.Text))       return ShowValidationError("Pole 'Email' jest wymagane.", textEmail);
            if (string.IsNullOrWhiteSpace(textPhone.Text))       return ShowValidationError("Pole 'Telegfon' jest wymagane.", textPhone);

            if (string.IsNullOrWhiteSpace(textWebsite.Text))     return ShowValidationError("Pole 'Strona (Website)' jest wymagane.", textWebsite);
            if (string.IsNullOrWhiteSpace(textStreet.Text))      return ShowValidationError("Pole 'Ulica' jest wymagane.", textStreet);
            if (string.IsNullOrWhiteSpace(textSuite.Text))       return ShowValidationError("Pole 'Nr. lokalu' jest wymagane.", textSuite);
            if (string.IsNullOrWhiteSpace(textCity.Text))        return ShowValidationError("Pole 'Miasto' jest wymagane.", textCity);
            if (string.IsNullOrWhiteSpace(textZipcode.Text))     return ShowValidationError("Pole 'Kod pocztowy' jest wymagane.", textZipcode);

            if (string.IsNullOrWhiteSpace(textLatitude.Text))     return ShowValidationError("Pole 'Szerokość geograficzna' jest wymagane.", textLatitude);
            if (string.IsNullOrWhiteSpace(textLongitude.Text))     return ShowValidationError("Pole 'Długość geograficzna' jest wymagane.", textLongitude);

            if (string.IsNullOrWhiteSpace(textCompanyName.Text)) return ShowValidationError("Pole 'Nazwa firmy' jest wymagane.", textCompanyName);
            if (string.IsNullOrWhiteSpace(textCatchPhrase.Text)) return ShowValidationError("Pole 'Slogan' jest wymagane.", textCatchPhrase);
            if (string.IsNullOrWhiteSpace(textBs.Text))          return ShowValidationError("Pole 'BS (Balance Sheet)' jest wymagane.", textBs);

            return true; /* Gdy wszystkie dane są podane */
        }

        





        private bool ShowValidationError(string message, Control controlToFocus)
        {
            MessageBox.Show(message, "Błąd walidacji", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            controlToFocus?.Focus(); // Ustaw fokus na błędnej kontrolce
            return false; // Sygnalizuj błąd walidacji
        }

        
        // protected override void Dispose(bool disposing)
        // {
        //     if (disposing && (components != null)) { components.Dispose(); }
        //     base.Dispose(disposing);
        // }
    }
}