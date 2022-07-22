﻿using MyContactBook.DbRealization;
using MyContactBook.Models;
using MyContactBook.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContactBook.Commands
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
                Contact contact = new() { FirstName = "test" };
                db.Contacts.Add(contact);
                _contactsViewModel.SelectedContact = contact;
                db.SaveChanges();
                _contactsViewModel.Contacts.Add(contact);
            }
        }
    }
}