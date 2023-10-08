using DirectoryApp.Model;
using DirectoryApp.View;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.ObjectModel;
using DirectoryApp.ViewModel;

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

        private async void RegisterPage(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(Register));
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

        private async void Login_Clicked(object sender, EventArgs e)
        {
            //HomeViewModel HomeViewModelPage = new HomeViewModel();
            bool IsValidated = ValidateForm();
            if (IsValidated == true)
            {
                await DisplayAlert("Login Alert", "Login successfull","Close");
                await Shell.Current.GoToAsync($"{nameof(Home)}?id={inputUsername.Text}");
                //await Navigation.PushAsync(new Home(inputUsername.Text));

            }
            else
            {

                await DisplayAlert("Login Alert", "Login unsuccessfull, please register.", "Close");
            }

        }
    }
}