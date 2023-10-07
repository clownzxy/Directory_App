using DirectoryApp.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace DirectoryApp.ViewModel;


public class HomeViewModel : ContentPage,INotifyPropertyChanged
{
    string maindir = FileSystem.Current.AppDataDirectory;
    public ObservableCollection<ContactsModel> contactCollection = new ObservableCollection<ContactsModel>();
    private string _studentID;
    public string StudentId
    {
        get { return _studentID; }
        set { _studentID = value;
            OnPropertyChanged();
        }
    }
    public ObservableCollection<ContactsModel> ContactCollection
    {
        get { return contactCollection; }
        set { contactCollection = value;
            OnPropertyChanged();}
    }

    public HomeViewModel()
    {
        ConvertToProductCollection(StudentId);
    }



    public void ConvertToProductCollection(string StudentId)
    {
        //DisplayAlert(Title, atay,"atay");
        string filePath = Path.Combine(maindir, $"S[{StudentId}].json");

        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            ContactCollection = JsonSerializer.Deserialize<ObservableCollection<ContactsModel>>(jsonData);
        }

    }

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}