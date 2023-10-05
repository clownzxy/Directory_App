using DirectoryApp.Model;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DirectoryApp;


public class RegisterViewModel
{
    private ObservableCollection<Student> productCollection = new ObservableCollection<Student>();
    string maindir = FileSystem.Current.AppDataDirectory;
    public ObservableCollection<Student> ProductCollection
    {
        get { return productCollection; }
        set { productCollection = value; }
    }

    public RegisterViewModel() {
        FileCreate(productCollection);
        ConvertToProductCollection();
    }

    

	

    public void AddStudent(Student student)
    {

        productCollection.Add(student);

        SaveToFile(student);
    }

    public void SaveToFile(Student student)
    {
        string filePath = Path.Combine(maindir, "Users.json");

        var json = string.Empty;
        json = JsonSerializer.Serialize(productCollection);

        File.WriteAllText(filePath, json);

        StudentFileCreate(student);
    }

    public void ConvertToProductCollection()
    {
        string filePath = Path.Combine(maindir, "Users.json");

        if(File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
            productCollection = JsonSerializer.Deserialize<ObservableCollection<Student>>(jsonData);
        }
        
    }

    public void StudentFileCreate(Student student)
    {
            string filePath = Path.Combine(maindir, ($"S[{student.StudentID}].json"));
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }
        
    }

    public void FileCreate(ObservableCollection<Student>productCollection)
    {
        string filePath = Path.Combine(maindir, "Users.json");
        productCollection.Add(null);

        var jsonData = JsonSerializer.Serialize(productCollection);


        if (!File.Exists(filePath))
        {

            File.WriteAllText(filePath, jsonData);
        }
    }
}