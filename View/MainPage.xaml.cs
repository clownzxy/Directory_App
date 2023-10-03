using DirectoryApp.ViewModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DirectoryApp
{
    public partial class MainPage : ContentPage
    {
        string user = "admin";
        string pass = "123";

       MainPageViewModel viewModel = new MainPageViewModel();

        public MainPage()
        {
            InitializeComponent();
            viewModel.FileCreate();

        }

        private void RegisterPage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Register());
        }



        private void Login_Clicked(object sender, EventArgs e)
        {
            if (user.ToLower().CompareTo(inputUsername.Text) == 0 && pass.ToLower().CompareTo(inputPassword.Text) == 0)
            {
                sysMessage.Text = "Login Success";
            }
            else if (String.IsNullOrEmpty(inputUsername.Text))
            {
                sysMessage.Text = "“Username and/or Password should not be empty. Please try again.”";
            }
            else
            {
                sysMessage.Text = "Username and/or Password is incorrect. Please try again";
            }


        }
    }
}