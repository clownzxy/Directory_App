namespace DirectoryApp.Model;


    public class Student
    {
    public string StudentID { get; set; }
    public string StudentName { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public string SchoolProgram { get; set; }
    public string Course { get; set; }
    public string Year { get; set; }
    public string Gender { get; set; }
    public string MobileNumber { get; set; }
    public string City { get; set; }
    public String BirthDate { get; set; }

    

    public Student(string studentID, 
        string firstName, 
        string lastName, 
        string email, 
        string password
        , string confirmPassword, 
        string schoolProgram,
        string course,
        string year,
        string gender, 
        string mobileNumber,
        string city, 
        String birthDate)
    {
        StudentID = studentID;
        StudentName = firstName;
        LastName = lastName;
        FirstName = firstName;
        Email = email;
        Password = password;
        ConfirmPassword = confirmPassword;
        SchoolProgram = schoolProgram;
        Course = course;
        Year = year;
        Gender = gender;
        MobileNumber = mobileNumber;
        City = city;
        BirthDate = birthDate;
    }
    
        

        

    }