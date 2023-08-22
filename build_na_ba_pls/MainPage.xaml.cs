namespace build_na_ba_pls
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        int anothercount=0;
        public MainPage()
        {
            InitializeComponent();
        }

        private void Login_Clicked(object sender, EventArgs e)
        {
            count+=1000;

            if (count == 1)
                LoginBtn.Text = $"Clicked {count} time";
            else
                LoginBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(LoginBtn.Text);
        }


    }


}