﻿using MyContactBook.Commands;
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
        #endregion

        #region Constructor
        public ContactsViewModel()
        {
            addCommand = new AddContactCommand(this);
            deleteCommand = new DeleteContactCommand(this);
            updateCommand = new UpdateContactCommand(this);
            using (DataContext db = new DataContext())
            {
                Contacts = new ObservableCollection<Contact>(db.Contacts.ToList());
            }
        } 
        #endregion
    }
}