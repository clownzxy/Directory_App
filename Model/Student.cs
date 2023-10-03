namespace DirectoryApp.Model;


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