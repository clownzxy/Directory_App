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
    private String _studentID;
    public String StudentId
    {
        get { return _studentID; }
        set { _studentID = value;
            OnPropertyChanged();
            ConvertToProductCollection(StudentId);
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
        //ConvertToProductCollection(studid);
    }



    public void ConvertToProductCollection(String StudentId)
    {
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