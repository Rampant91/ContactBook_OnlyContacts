using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MyContactBook.Models
{
    public class Contact : INotifyPropertyChanged
    {
        private bool _editeble;
        public bool Editeble
        {
            get => _editeble; 
            set { _editeble = value; OnPropertyChanged(nameof(Editeble)); }
        }

        private string? _firstName;
        public string? FirstName
        {
            get => _firstName; 
            set { _firstName = value; OnPropertyChanged(nameof(FirstName)); }
        }

        private string? _lastName;
        public string? LastName
        {
            get => _lastName;
            set { _lastName = value; OnPropertyChanged(nameof(LastName)); }
        }

        private string? _patronymic;
        public string? Patronymic
        {
            get => _patronymic;
            set { _patronymic = value; OnPropertyChanged(nameof(Patronymic)); }
        }

        private string? _phone;
        public string? Phone
        {
            get => _phone;
            set { _phone = value; OnPropertyChanged(nameof(Phone)); }
        }

        private string? _email;
        public string? Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(nameof(Email)); }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyChanged = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyChanged));
        }
    }
}
