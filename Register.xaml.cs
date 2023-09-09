using System.Collections.ObjectModel;

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
            "SBM"
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

    public class Student : ContentPage
    {
        private int _studentID;
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

        public int StudentID
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
                return this._password;
            }
            set
            {
                this._password = value;
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
    }

    private Student theUser()
    {
        Student theStudent = new Student();
        theStudent.StudentID = int.Parse(entryStudentID.Text);
        theStudent.FirstName = entryFirstName.Text;
        theStudent.LastName = entryLastName.Text;
        theStudent.Email = entryEmail.Text;
        theStudent.Password = entryPassword.Text;
        theStudent.ConfirmPassword = entryConfirmPassword.Text;
        //no gender yet idk how to do that shit same with birth date
        theStudent.MobileNumber = entryMobileNumber.Text;
        theStudent.City = entryCity.Text;




        return theStudent;
    }





    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        Course.Clear();
        if (selectedIndex == 1)
        {
            Course.Add("BSCPE");
            Course.Add("BSCE");
            Course.Add("BSCE");
        }
        else if (selectedIndex == 2)
        {
            Course.Add("BSOM");
            Course.Add("BSACC");
        }
    }



}
