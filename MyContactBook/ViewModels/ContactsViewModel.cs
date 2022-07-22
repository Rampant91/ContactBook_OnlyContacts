using MyContactBook.Commands;
using MyContactBook.DbRealization;
using MyContactBook.Models;
using System.Collections.ObjectModel;
using System.Linq;

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
            set 
            { 
                _lastName = value; 
                OnPropertyChanged(nameof(LastName)); 
            }
        }
        #endregion

        public ContactsViewModel()
        {
            using (DataContext db = new DataContext())
            {
                Contacts = new ObservableCollection<Contact>(db.Contacts.ToList());
            }
        }

        #region Commands
        private RelayCommand? _addContact;
        public RelayCommand? AddContact
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

        private bool _editable = false;
        public bool Editable
        {
            get => _editable;
            set 
            { 
                _editable = value; 
                OnPropertyChanged(nameof(Editable)); 
            }
        }

        private RelayCommand? _editContact;
        public RelayCommand? EditContact
        {
            get
            {
                addCommand = new AddContactCommand(this);
                deleteCommand = new DeleteContactCommand(this);
                editCommand = new EditContactCommand(this);
                updateCommand = new UpdateContactCommand(this);
                using (DataContext db = new DataContext())
                {
                    return _editContact ??= new RelayCommand(obj =>
                    {
                        SelectedContact.Editeble = true;
                    }, obj => SelectedContact != null);
                }
            }
        }
        #endregion
    }
}