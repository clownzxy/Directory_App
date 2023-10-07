using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DirectoryApp.Model;

public class ContactsModel : INotifyPropertyChanged
{
		
    public string Type { get; set; } 
	public string ID { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Email { get; set; }
	public string MobileNo { get; set; }
	public string School { get; set; }
	public string Course { get; set; }

    public ContactsModel(string type,string id,string firstName,string lastName,string email,
		string mobileNo,string school,string course)
	{
		Type = type;
		ID = id;
		FirstName = firstName;
		LastName = lastName;
		Email = email;
		MobileNo = mobileNo;
		School = school;
		Course = course;
		OnPropertyChanged();
	}

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}