namespace build_na_ba_pls
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        string user = "admin";
        string pass = "123";
        public MainPage()
        {
            InitializeComponent();
        }

        private void Login_Clicked(object sender, EventArgs e)
        {
            if (user.ToLower().CompareTo(inputUsername.Text) == 0 && pass.ToLower().CompareTo(inputPassword.Text)==0)
            {
                sysMessage.Text = "Login Success";
            }else if(String.IsNullOrEmpty(inputUsername.Text)){
                sysMessage.Text = "“Username and/or Password should not be empty. Please try again.”";
            }
            else
            {
                sysMessage.Text = "Username and/or Password is incorrect. Please try again";
            }

            
        }



    }


}