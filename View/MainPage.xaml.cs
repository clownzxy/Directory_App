using DirectoryApp.Model;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.ObjectModel;

namespace DirectoryApp
{
    public partial class MainPage : ContentPage
    {
        string maindir = FileSystem.Current.AppDataDirectory;

        private ObservableCollection<Student> _students;

        public ObservableCollection<Student> Students
        {
            get
            {
                return _students;
            }
            set
            {
                _students = value;
            }
        }

        public MainPage()
        {
            InitializeComponent();

        }

        private void RegisterPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Register());
        }

        public bool ValidateForm()
        {

            bool firstEntry = true;
            var filePath = Path.Combine(maindir, "Users.json");
      //StudentData = JsonSerializer.Deserialize<ObservableCollection<Student>>(jsonData);*/

     

      string jsonData = File.ReadAllText(filePath);
            Students = JsonSerializer.Deserialize<ObservableCollection<Student>>(jsonData);

            foreach ( Student student in Students)
            {
                if (student.StudentID == inputUsername.Text&&student.Password==inputPassword.Text)
                {
                    firstEntry = true;
                    break;
                }
                else
                {
                    firstEntry= false;
                }

            }

            if(firstEntry)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void Login_Clicked(object sender, EventArgs e)
        {

            bool IsValidated = ValidateForm();
            if (IsValidated == true)
            {
                DisplayAlert("Login Alert", "Login successfull","Close");
                Navigation.PushAsync(new Home());

            }
            else
            {

                DisplayAlert("Login Alert", "Login unsuccessfull", "Close");
                Navigation.PushAsync(new Register());
            }

        }
    }
}