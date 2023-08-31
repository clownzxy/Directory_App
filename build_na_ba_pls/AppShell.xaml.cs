namespace build_na_ba_pls
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Register), typeof(Register));
        }
    }
}