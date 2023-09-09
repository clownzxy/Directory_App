using CommunityToolkit.Maui.Views;

namespace DirectoryApp;

public partial class PopupPage : Popup
{
    public Student theStudent { get; set; }


    public PopupPage(Student theStudent)
    {
        InitializeComponent();
        this.theStudent = theStudent;
        BindingContext = theStudent;
    }


}



