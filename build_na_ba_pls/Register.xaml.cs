using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Microsoft.Maui.Controls;

namespace build_na_ba_pls;

public partial class Register : ContentPage, INotifyPropertyChanged
{
	private ObservableCollection<String> _schoolProgram=new ObservableCollection<String>();
	private ObservableCollection<String>_course = new ObservableCollection<String>();
	private ObservableCollection<String>Year_Level = new ObservableCollection<String>();

	public ObservableCollection<String> SchoolProgram
	{
		get => _schoolProgram;
		set
		{
			_schoolProgram = value;
			OnPropertyChanged(nameof(SchoolProgram));
		}
	}

	public ObservableCollection<String> Course
	{
		get => _course;
		set
		{
			_course = value;
			OnPropertyChanged(nameof(Course));
		}
	}

    public Register()
	{
		InitializeComponent();
		SchoolProgram = new ObservableCollection<String>
		{
			"--SELECT--",
			"SOE",
			"SBM"
		};


		Course = new ObservableCollection<string>
		{
			"--select--"
		};
		BindingContext = this;
	}

    private void opawallen_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;


        Course.Clear();
        if (selectedIndex == 1)
        {
            Course.Add("BSCE");
            Course.Add("BSCPE");
            Course.Add("BSECE");
            Course.Add("BSIE");
            Course.Add("BSEE");
            Course.Add("BSME");
        }
        else if (selectedIndex == 2)
        {
            Course.Add("BSACC");
            Course.Add("BSHR");
        }
        else
        {
            Course.Add("-SELECT-");
        }
    }






}

