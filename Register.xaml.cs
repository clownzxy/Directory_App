using CommunityToolkit.Maui.Views;
using System.Collections.ObjectModel;
using static System.String;

namespace DirectoryApp;

public partial class Register : ContentPage
{
    private ObservableCollection<String> _schoolProgram;
    private ObservableCollection<String> _course;
    private ObservableCollection<String> _yrLvl;

    public ObservableCollection<String> SchoolProgram
    {
        get { return _schoolProgram; }
        set { _schoolProgram = value; }
    }

    public ObservableCollection<String> Course
    {
        get { return _course; }
        set { _course = value; }
    }

    public ObservableCollection<String> YrLvl
    {
        get { return _yrLvl; }
        set { _yrLvl = value; }
    }


    public Register()
    {
        InitializeComponent();

        ObservableCollection<String> SchoolProgram = new ObservableCollection<String>()
        {
            "-SELECT-",
            "SOE",
            "SBM",
            "SAS",
            "SOED",
            "SCS",
            "SAMS",
            "SOL",
        };

        Course = new ObservableCollection<string>
        {
            "-SELECT-"
        };

        ObservableCollection<String> YrLvl = new ObservableCollection<string>
        {
            "-SELECT-",
            "1st Year",
            "2nd Year",
            "3rd Year",
            "4th Year",
            "Irregular"
        };

        picker.ItemsSource = SchoolProgram;
        coursePicker.ItemsSource = Course;
        yrLvlPicker.ItemsSource = YrLvl;
        picker.SelectedItem = "-SELECT-";
        coursePicker.SelectedItem = "-SELECT-";
        yrLvlPicker.SelectedItem = "-SELECT-";
        picker.SelectedIndexChanged += Picker_SelectedIndexChanged;
        this.BindingContext = this;
    }

    


    private Student theUser()
    {

        Student theStudent = new Student();
        theStudent.StudentID = entryStudentID.Text;
        theStudent.FirstName = entryFirstName.Text;
        theStudent.LastName = entryLastName.Text;
        theStudent.Email = entryEmail.Text;
        theStudent.Password = entryPassword.Text;
        theStudent.ConfirmPassword = entryConfirmPassword.Text;
        theStudent.Gender = radioGenderIsCheck();
        theStudent.MobileNumber = entryMobileNumber.Text;
        theStudent.City = entryCity.Text;
        theStudent.BirthDate = datePickerBirthDate.Date.ToString("dd/MM/yyyy");
        theStudent.SchoolProgram = picker.SelectedItem.ToString();
        theStudent.Courses = coursePicker.SelectedItem.ToString();
        theStudent.Year = yrLvlPicker.SelectedItem.ToString();
        return theStudent;
    }
    
        
    



    public int radioGenderIsCheck()
    {
        if (radioMale.IsChecked || radioFemale.IsChecked == true)
        {
            return 1;
        }
        else { return 0; }
    }

    public bool ValidateForm()
    {
        bool firstEntry = false;
        bool secondEntry = false;

        secondEntry = !IsNullOrEmpty(picker.SelectedItem.ToString()) && !IsNullOrEmpty(coursePicker.SelectedItem.ToString())
        && !IsNullOrEmpty(yrLvlPicker.SelectedItem.ToString());

        if (entryStudentID.Text != null && entryFirstName.Text != null && entryLastName.Text != null && entryEmail.Text != null
            && entryPassword.Text != null && entryConfirmPassword.Text == entryPassword.Text && radioGenderIsCheck() == 1
            && entryMobileNumber.Text != null && entryCity.Text != null && datePickerBirthDate != null)
        {
            firstEntry = true;
        }

        if (firstEntry&&secondEntry==true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void SubmitbtnIsClicked(object sender, EventArgs e)
    {
        var popup = new PopupPage(theUser());

        bool IsValidated = ValidateForm();
        if (IsValidated==true)
        {
            txtSysMessage.Text = "Success";
            txtSysMessage.TextColor = Colors.Green;
            this.ShowPopup(popup);
        }
        else
        {
            txtSysMessage.Text = "Invalid Input";
            txtSysMessage.TextColor = Colors.Red;
            
        }
    }

    public async void ResetForm()
    {
        // Get current page
        var page = Navigation.NavigationStack.LastOrDefault();

        // Load new page
        await Shell.Current.GoToAsync(nameof(Register), false);

        // Remove old page
        Navigation.RemovePage(page);
    }


    private void ResetbtnIsClicked(object sender, EventArgs e)
    {
        ResetForm();
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
        if (selectedIndex == 1)
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
        }else if(selectedIndex == 3)
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
        }else if (selectedIndex == 4)
        {
            Course.Add("BS-Educ");
        }else if (selectedIndex == 5)
        {
            Course.Add("BSCS");
            Course.Add("BSIT");
            Course.Add("BSIS");
        }else if (selectedIndex == 6)
        {
            Course.Add("BS-Nursing");
        }else if (selectedIndex == 7)
        {
            Course.Add("BS-Law");
        }
    }



}

public class Student
{
    private string _studentID;
    private string _firstName;
    private string _lastName;
    private string _email;
    private string _password;
    private string _confirmPassword;
    private string _schoolProgram;
    private string _course;
    private string _year;
    private int _gender;
    private string _mobileNumber;
    private string _city;
    private String _birthDate;

    public String StudentID
    {
        get
        {
            return this._studentID;
        }
        set
        {
            this._studentID = value;
        }
    }

    public string FirstName
    {
        get
        {
            return this._firstName;
        }
        set
        {
            this._firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return this._lastName;
        }
        set
        {
            this._lastName = value;
        }
    }

    public string Email
    {
        get
        {
            return this._email;
        }
        set
        {
            this._email = value;
        }
    }

    public string Password
    {
        get { return this._password; }
        set { this._password = value; }
    }

    public string ConfirmPassword
    {
        get
        {
            return this._confirmPassword;
        }
        set
        {
            this._confirmPassword = value;
        }
    }

    public string Courses
    {
        get
        {
            return this._course;
        }
        set
        {
            this._course = value;
        }
    }

    public string SchoolProgram
    {
        get
        {
            return this._schoolProgram;
        }

        set
        {
            this._schoolProgram = value;
        }
    }

    public string Year
    {
        get
        {
            return this._year;
        }

        set
        {
            this._year = value;
        }
    }

    public int Gender
    {
        get
        {
            return this._gender;
        }

        set
        {
            this._gender = value;
        }
    }

    public string MobileNumber
    {
        get
        {
            return this._mobileNumber;
        }
        set
        {
            this._mobileNumber = value;
        }
    }

    public string City
    {
        get
        {
            return this._city;
        }
        set
        {
            this._city = value;
        }
    }

    public String BirthDate
    {
        get
        {
            return this._birthDate;
        }
        set
        {
            this._birthDate = value;
        }
    }
}