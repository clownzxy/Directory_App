using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Maui.Views;
using DirectoryApp.Model;
using System.Collections.ObjectModel;
using System.Text.Json;
using static System.String;

namespace DirectoryApp;

public partial class Register : ContentPage
{
    string maindir = FileSystem.Current.AppDataDirectory;
    private ObservableCollection<String> _schoolProgram;
    private ObservableCollection<String> _course;
    private ObservableCollection<String> _yrLvl;
    RegisterViewModel studentViewModel = new RegisterViewModel();
    private ObservableCollection<Student> _students;
    private ObservableCollection<Student> _studentData;
    public ObservableCollection<String> SchoolProgram
    {
        get { return _schoolProgram; }
        set { _schoolProgram = value; }
    }

    public ObservableCollection<Student> StudentData
    {
        get { return _studentData;}
        set { _studentData = value; }
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

    public ObservableCollection<Student> Students
    {
        get { return _students; }
        set { _students = value; }
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

        ObservableCollection<String> YrLvl = new ObservableCollection<String>
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
        BindingContext = studentViewModel;
    }

    


    /*private Student theUser()
    {

        /*Student theStudent = new Student();
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
    */
        
    
        
    



    public string radioGenderIsCheck()
    {
        if (radioMale.IsChecked = true)
        {
            return "Male";
        }
        else { return "Female"; }
    }

    public bool ValidateForm()
    {

        bool firstEntry = true;
        bool secondEntry = true;
        var filePath = Path.Combine(maindir, "Users.json");
        //StudentData = JsonSerializer.Deserialize<ObservableCollection<Student>>(jsonData);*/

        string jsonData = File.ReadAllText(filePath);
        Students = JsonSerializer.Deserialize<ObservableCollection<Student>>(jsonData);

        foreach(Student student in Students)
        {
            if (student.StudentID == entryStudentID.Text)
            {
                firstEntry = false;
            }
            else if(student.StudentID!=entryStudentID.Text)
            {
                firstEntry = true;
            }
        }
        
        /*if (entryStudentID.Text != null && entryFirstName.Text != null && entryLastName.Text != null && entryEmail.Text != null
            && entryPassword.Text != null && entryConfirmPassword.Text == entryPassword.Text
            && entryMobileNumber.Text != null && entryCity.Text != null && datePickerBirthDate != null)
        {
            firstEntry = true;
        }
        else
        {
            firstEntry = false;
        }*/

        secondEntry = !IsNullOrEmpty(picker.SelectedItem.ToString()) && !IsNullOrEmpty(coursePicker.SelectedItem.ToString())
        && !IsNullOrEmpty(yrLvlPicker.SelectedItem.ToString());

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
        bool IsValidated = ValidateForm();
        if (IsValidated==true)
        {
            txtSysMessage.Text = "Success";
            txtSysMessage.TextColor = Colors.Green;

            Student student = new Student(entryStudentID.Text,
            entryFirstName.Text,
            entryLastName.Text,
            entryEmail.Text,
            entryPassword.Text,
            entryConfirmPassword.Text,
            picker.SelectedItem.ToString(),
            coursePicker.SelectedItem.ToString(),
            yrLvlPicker.SelectedItem.ToString(),
            radioGenderIsCheck(),
            entryMobileNumber.Text,
            entryCity.Text,
            datePickerBirthDate.Date.ToString("dd/MM/yyyy"));

            //Students.Add(student);
            studentViewModel.AddStudent(student);
            //this.ShowPopup(popup);
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
        await Navigation.PushAsync(new Register());

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
