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
        get { return _yrLvl;}
        set { _yrLvl = value; }
    }


    public Register()
	{
		InitializeComponent();

        ObservableCollection<String>SchoolProgram = new ObservableCollection<String>()
        {
            "DEFAULT",
            "SOE",
            "SBM"
        };

        ObservableCollection<String>Course = new ObservableCollection<string>
        {
            "DEFAULT"
        };

        ObservableCollection<String> YrLvl = new ObservableCollection<string>
        {
            "DEFAULT",
            "1st Year",
            "2nd Year",
            "3rd Year",
            "4th Year",
            "Irregular"
        };

        picker.ItemsSource = SchoolProgram;
        coursePicker.ItemsSource = Course;
        yrLvlPicker.ItemsSource = YrLvl;
        picker.SelectedItem = "DEFAULT";
        coursePicker.SelectedItem = "DEFAULT";
        yrLvlPicker.SelectedItem = "DEFAULT";
        picker.SelectedIndexChanged += Picker_SelectedIndexChanged;
        this.BindingContext = this;
    }

    

    

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        Course.Clear();
        if(selectedIndex == 1 ) 
        {
            Course.Add("BSCPE");
            Course.Add("BSCE");
            Course.Add("BSCE");
        }else if(selectedIndex == 2) 
        {   
            Course.Add("BSOM");
            Course.Add("BSACC");
        }
    }

}
