using System.Collections.ObjectModel;
using DirectoryApp.View;
using DirectoryApp.Model;
using System.Text.Json;

namespace DirectoryApp.ViewModel;

public class AddContactFormViewModel : ContentPage
{
    string maindir = FileSystem.Current.AppDataDirectory;
    public ObservableCollection<ContactsModel> contactCollection = new ObservableCollection<ContactsModel> ();
    public ObservableCollection<ContactsModel> ContactCollection
    {
        get { return contactCollection; }
        set { contactCollection = value; }
    }

    public AddContactFormViewModel()
	{
        //ConvertToProductCollection(StudentId);
        //AddStudent(contacts, StudentId);
    }

    public void AddStudent(ContactsModel contacts,string StudentId)
    {
        ConvertToProductCollection(StudentId);

        contactCollection.Add(contacts);
        SaveToFile(contacts,StudentId);
    }

    public void SaveToFile(ContactsModel contacts, string StudentId)
    {
        string filePath = Path.Combine(maindir, $"S[{StudentId}].json");

        var json = string.Empty;
        json = JsonSerializer.Serialize(contactCollection);

        File.WriteAllText(filePath, json);
    }

    public void ConvertToProductCollection(string StudentId)
    {
        string filePath = Path.Combine(maindir, $"S[{StudentId}].json");

        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            contactCollection = JsonSerializer.Deserialize<ObservableCollection<ContactsModel>>(jsonData);
        }

    }


    

}