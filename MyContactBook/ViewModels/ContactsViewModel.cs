using MyContactBook.Commands;
using MyContactBook.DbRealization;
using MyContactBook.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MyContactBook.ViewModels
{
    public class ContactsViewModel : BaseViewModel
    {
        #region Commands
        public ICommand addCommand { get; set; }
        public ICommand deleteCommand { get; set; }
        public ICommand editCommand { get; set; }
        public ICommand updateCommand { get; set; }
        #endregion

        #region Contacts
        private ObservableCollection<Contact> _contacts;
        public ObservableCollection<Contact> Contacts
        {
            get => _contacts;
            set
            {
                _contacts = value;
                OnPropertyChanged(nameof(Contacts));
            }
        }
        #endregion

        #region SelectedContact
        private Contact? _selectedContact;
        public Contact? SelectedContact
        {
            get => _selectedContact;
            set
            {
                _selectedContact = value;
                OnPropertyChanged(nameof(SelectedContact));
            }
        }
        #endregion

        #region ContactProperties
        private string? _firstName;
        public string? FirstName
        {
            get => _firstName;
            set 
            { 
                _firstName = value; 
                OnPropertyChanged(nameof(FirstName)); 
            }
        }

        private string? _lastName;
        public string? LastName
        {
            get => _lastName;
            set { _lastName = value; OnPropertyChanged(nameof(LastName)); }
        }
        #endregion

        private string? _patronymic;
        public string? Patronymic
        {
            get => _patronymic;
            set { _patronymic = value; OnPropertyChanged(nameof(Patronymic)); }
        }

        private string? _phone;
        public string? Phone
        {
            get
            {
                return _addContact ??= new RelayCommand(obj =>
                    {
                    using (DataContext db = new DataContext())
                        {
                            Contact contact = new() { FirstName = "test" };
                            db.Contacts.Add(contact);
                            SelectedContact = contact;
                            db.SaveChanges();
                            Contacts.Add(contact);
                        }
                    });
            }
        }

        private string? _email;
        public string? Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(nameof(Email)); }
        }
        #endregion

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