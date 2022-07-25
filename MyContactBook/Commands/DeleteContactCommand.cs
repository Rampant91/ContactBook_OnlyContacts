using ContactBook_OnlyContacts.DbRealization;
using ContactBook_OnlyContacts.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook_OnlyContacts.Commands
{
    public class DeleteContactCommand : BaseCommand
    {
        private readonly ContactsViewModel _contactsViewModel;

        public DeleteContactCommand(ContactsViewModel contactsViewModel)
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
            return _contactsViewModel.SelectedContact != null;
        }

        public override void Execute(object? parameter)
        {
            var contact = _contactsViewModel.SelectedContact = null!;
            using (DataContext db = new DataContext())
            {
                var contactDb = db.Contacts.FirstOrDefault(x => x.Id == contact.Id);
                if (contactDb != null)
                {
                    db.Contacts.Remove(contactDb);
                    _contactsViewModel.Contacts.Remove(contact);
                    db.SaveChanges();
                }
            }
        }
    }
}