using MyContactBook.Commands;
using MyContactBook.Models;
using System.Collections.ObjectModel;

namespace MyContactBook.ViewModels
{
    public class ContactsViewModel : BaseViewModel
    {
        #region Contacts
        private ObservableCollection<Contact> _contacts = new ObservableCollection<Contact>();
        public ObservableCollection<Contact> Contacts
        {
            get => _contacts;
            set
            {
                _contacts = value;
                OnPropertyChanged(nameof(Contacts));
            }
        }

        private Contact? _selectedContact;
        public Contact? SelectedContact
        {
            get => _selectedContact;
            set { _selectedContact = value; OnPropertyChanged(nameof(SelectedContact)); }
        }
        #endregion

        #region ContactProperties
        private string? _firstName;
        public string? FirstName
        {
            get { return _firstName; }
            set { _firstName = value; OnPropertyChanged(nameof(FirstName)); }
        }

        private string? _lastName;
        public string? LastName
        {
            get { return _lastName; }
            set { _lastName = value; OnPropertyChanged(nameof(LastName)); }
        }
        #endregion

        public ContactsViewModel()
        {
            Contacts = new ObservableCollection<Contact>
            {
                new Contact {FirstName = "Andrey", LastName= "Ostap"},
                new Contact {FirstName = "Anton", LastName= "Plowenko"},
                new Contact {FirstName = "Leni4"}
            };
        }

        #region Commands
        private RelayCommand? _addContact;
        public RelayCommand? AddContact
        {
            get
            {
                return _addContact ??= new RelayCommand(obj =>
                    {
                        Contact contact = new() { FirstName = "test" };
                        Contacts.Insert(0, contact);
                        SelectedContact = contact;
                    });
            }
        }

        private RelayCommand? _deleteContact;
        public RelayCommand? DeleteContact
        {
            get
            {
                return _deleteContact ??= new RelayCommand(
                    obj => Contacts.Remove(obj as Contact),
                    obj => SelectedContact is Contact);
            }
        }

        private RelayCommand? _editContact;
        public RelayCommand? EditContact
        {
            get
            {
                return _editContact ??= new RelayCommand(obj =>
                    {
                        SelectedContact.Editeble = true;
                    }, obj => SelectedContact != null);
            }
        }
        #endregion
    }
}