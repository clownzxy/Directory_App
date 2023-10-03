using System.Collections.ObjectModel;
using System.Text.Json;

namespace DirectoryApp.ViewModel;

public class MainPageViewModel : ContentPage
{
    string maindir = FileSystem.Current.AppDataDirectory;

    public void FileCreate()
    {
        string filePath = Path.Combine(maindir, "Users.json");
        if (!File.Exists(filePath))
        {
            File.Create(filePath);
        }
    }

}