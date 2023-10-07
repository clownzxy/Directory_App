using DirectoryApp.ViewModel;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DirectoryApp.View;

[QueryProperty(nameof(StudentId),"id")]
public partial class Home : ContentPage , INotifyPropertyChanged
{
    HomeViewModel HomeViewModelPage = new HomeViewModel();

    private string _studentId;
    public string StudentId
{
    get {  return _studentId; }
    set { _studentId = value;
            OnPropertyChanged();
        }
}

    
    public Home()
	{
		InitializeComponent();
        //DisplayAlert("Home", StudentId,"atay");
        if(StudentId != null)
        {
            ReadFile();

        }
        BindingContext = HomeViewModelPage;
    }


    public void ReadFile()
    {

        HomeViewModelPage.ConvertToProductCollection(StudentId);
    }



    private async void clickedAddContactForms(object sender, EventArgs e)
    {
        string studentId=StudentId;
        await Shell.Current.GoToAsync($"{nameof(AddContactForm)}?id={StudentId}");
    }



}