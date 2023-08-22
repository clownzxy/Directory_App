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
                sysMessage.Text = "Field is empty";
            }
            else
            {
                sysMessage.Text = "Login Failed";
            }

            
        }



    }


}