﻿using ContactBook_OnlyContacts.DbRealization;
using ContactBook_OnlyContacts.Models;
using ContactBook_OnlyContacts.ViewModels;
using System.ComponentModel;

namespace ContactBook_OnlyContacts.Commands
{
    public class AddContactCommand : BaseCommand
    {
        private readonly ContactsViewModel _contactsViewModel;

        public AddContactCommand(ContactsViewModel contactsViewModel)
        {
            _contactsViewModel = contactsViewModel;
            _contactsViewModel.PropertyChanged += ContactsViewModelPropertyChanged;
        }

        private void ContactsViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ContactsViewModel.SelectedContact))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            using (DataContext db = new DataContext())
            {
                Contact contact = new Contact();
                db.Contacts.Add(contact);
                _contactsViewModel.SelectedContact = contact;
                db.SaveChanges();
                _contactsViewModel.Contacts.Add(contact);
            }
        }
    }
}