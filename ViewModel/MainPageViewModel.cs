using System.Collections.ObjectModel;
using System.Text.Json;
using DirectoryApp.Model;

namespace DirectoryApp;

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