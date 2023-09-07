namespace DirectoryApp;

public partial class Register : ContentPage
{
	public Register()
	{
		InitializeComponent();

        List<String> pickerList = new List<string>();
        pickerList.Add("Default");
        pickerList.Add("SOE");
        pickerList.Add("SBM");
        pickerList.Add("SAMS");

        List<String> course = new List<String>();
        course.Add("Default");

        picker.ItemsSource = pickerList;
        picker.SelectedItem = "Default";
        picker.SelectedIndexChanged += Picker_SelectedIndexChanged;

    }

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;


        if (selectedIndex == 1 )
        {
            //course.Add("CPE");
        }
    }

}
