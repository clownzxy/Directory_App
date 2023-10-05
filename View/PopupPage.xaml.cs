using CommunityToolkit.Maui.Views;
using DirectoryApp.Model;

namespace DirectoryApp;

public partial class PopupPage : Popup
{
    public Student theStudent { get; set; }


    public PopupPage(Student theStudent)
    {
        InitializeComponent();
        this.theStudent = theStudent;

    }

   




}



