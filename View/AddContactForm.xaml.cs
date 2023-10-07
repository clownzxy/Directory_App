using System.Collections.ObjectModel;
using DirectoryApp.Model;
using DirectoryApp.View;
using DirectoryApp.ViewModel;
using static System.String;

namespace DirectoryApp.View;

[QueryProperty(nameof(StudentId), "id")]
public partial class AddContactForm : ContentPage
{
    private string _studentId;
    public string StudentId
    {
        get { return _studentId; }
        set { _studentId = value; OnPropertyChanged(); }
    }
    AddContactFormViewModel AddContactFormViewModelPage = new AddContactFormViewModel();
    //Home home = new Home();
    private ObservableCollection<String> _schoolProgram;
    private ObservableCollection<String> _course;
    string maindir = FileSystem.Current.AppDataDirectory;

    public ObservableCollection<String> SchoolProgram
    {
        get
        {
            return _schoolProgram;
        }
        set
        {
            _schoolProgram = value;
        }
    }

    public ObservableCollection<String> Course
    {
        get
        {
            return _course;
        }
        set
        {
            _course = value;
        }
    }

    public AddContactForm()
    {
        InitializeComponent();

        ObservableCollection<String> SchoolProgram = new ObservableCollection<String>() {
      "-SELECT-",
      "SOE",
      "SBM",
      "SAS",
      "SOED",
      "SCS",
      "SAMS",
      "SOL",
    };

        Course = new ObservableCollection<String> {
      "-SELECT-"
    };

        pckSchool.ItemsSource = SchoolProgram;
        pckCourse.ItemsSource = Course;

        pckSchool.SelectedItem = "-SELECT-";
        pckCourse.SelectedItem = "-SELECT-";

        pckSchool.SelectedIndexChanged += Picker_SelectedIndexChanged;

        BindingContext = AddContactFormViewModelPage;
    }

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        /*
         * "-SELECT-",
        "SOE",
            "SBM",
            "SAS",
            "SOED",
            "SCS",
            "SAMS",
            "SOL",*/
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        Course.Clear();
        if (rdoFaculty.IsChecked == true)
        {
            Course.Clear();
        }
        else if (selectedIndex == 1)
        {
            Course.Add("BSCPE");
            Course.Add("BSCE");
            Course.Add("BSECE");
            Course.Add("BSEE");
            Course.Add("BSIE");
            Course.Add("BSME");

        }
        else if (selectedIndex == 2)
        {
            Course.Add("BSBA-HRDM");
            Course.Add("BSBA");
            Course.Add("BSBA-MM");
            Course.Add("BSBA-FM");
            Course.Add("BS-Entrep");
            Course.Add("BSA");
            Course.Add("BSMA");
            Course.Add("BSHM");
        }
        else if (selectedIndex == 3)
        {
            Course.Add("BAC");
            Course.Add("BAJ");
            Course.Add("BALIACOM");
            Course.Add("BSBIO");
            Course.Add("BAPS");
            Course.Add("BAIS");
            Course.Add("BA-PHILO");
            Course.Add("BA-PSYCH");
            Course.Add("BA-English");
        }
        else if (selectedIndex == 4)
        {
            Course.Add("BS-Educ");
        }
        else if (selectedIndex == 5)
        {
            Course.Add("BSCS");
            Course.Add("BSIT");
            Course.Add("BSIS");
        }
        else if (selectedIndex == 6)
        {
            Course.Add("BS-Nursing");
        }
        else if (selectedIndex == 7)
        {
            Course.Add("BS-Law");
        }
    }

    public string radioTypeIsChecked()
    {
        if (rdoFaculty.IsChecked == true)
        {
            return "Faculty";
        }
        else { return "Student"; }
    }

    public bool ValidateForm()
    {

        bool firstEntry = true;
        bool secondEntry = true;
        var filePath = Path.Combine(maindir, "Users.json");
        //StudentData = JsonSerializer.Deserialize<ObservableCollection<Student>>(jsonData);*/


        if (entryID.Text != null && entryFirstName.Text != null && entryLastName.Text != null && entryEmail.Text != null
            && entryMobileNo.Text != null)
        {
            firstEntry = true;
        }
        else
        {
            firstEntry = false;
        }

        if (rdoFaculty.IsChecked == true)
        {
            secondEntry = !IsNullOrEmpty(pckSchool.SelectedItem.ToString());

            if (firstEntry && secondEntry == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            secondEntry = !IsNullOrEmpty(pckSchool.SelectedItem.ToString()) && !IsNullOrEmpty(pckCourse.SelectedItem.ToString());

            if (firstEntry && secondEntry == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }

    private async void btnSubmitIsClicked(object sender, EventArgs e)
    {
        bool IsValidated = ValidateForm();
        if (IsValidated == true)
        {
            await DisplayAlert("Contact Form", "Operation Successful", "Close");

            if (rdoFaculty.IsChecked == true)
            {
                pckCourse.SelectedItem = " ";
                ContactsModel contacts = new ContactsModel(radioTypeIsChecked(),
            entryID.Text,
            entryFirstName.Text,
            entryLastName.Text,
            entryEmail.Text,
            entryMobileNo.Text,
            pckSchool.SelectedItem.ToString(),
            pckCourse.SelectedItem.ToString());
                AddContactFormViewModelPage.AddStudent(contacts, StudentId);
            }
            else
            {
                ContactsModel contacts = new ContactsModel(radioTypeIsChecked(),
                            entryID.Text,
                            entryFirstName.Text,
                            entryLastName.Text,
                            entryEmail.Text,
                            entryMobileNo.Text,
                            pckSchool.SelectedItem.ToString(),
                            pckCourse.SelectedItem.ToString());
                AddContactFormViewModelPage.AddStudent(contacts, StudentId);
            }


            //Students.Add(student);

            //this.ShowPopup(popup);
            //await Shell.Current.GoToAsync($"{nameof(Home)}?id={StudentId}");
            await Shell.Current.GoToAsync($"{nameof(Home)}");


        }
        else
        {
            await DisplayAlert("Contact Form", "Operation Unsuccessful", "Close");

        }
    }

}