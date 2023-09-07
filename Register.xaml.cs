using System.Collections.ObjectModel;

namespace DirectoryApp;

public partial class Register : ContentPage
{
    private ObservableCollection<String> _schoolProgram;
    private ObservableCollection<String> _course;

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


    public Register()
	{
		InitializeComponent();

        SchoolProgram = new ObservableCollection<String>()
        {
            "DEFAULT",
            "SOE",
            "SBM"
        };

        Course = new ObservableCollection<string>
        {
            "DEFAULT"
        };

        picker.ItemsSource = SchoolProgram;
        coursePicker.ItemsSource = Course;
        picker.SelectedItem = "Default";
        picker.SelectedIndexChanged += Picker_SelectedIndexChanged;
        BindingContext = this;
    }

    

    

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        Course.Clear();

        if (selectedIndex == 1 )
        {
            Course.Add("BSCPE");
            Course.Add("BSCE");
            Course.Add("BSCE");
            SchoolProgram.Remove("DEFAULT");
        }else if(selectedIndex == 2 ) 
        {
            Course.Add("BSACC");
            Course.Add("BSOM");
        }
    }

}
