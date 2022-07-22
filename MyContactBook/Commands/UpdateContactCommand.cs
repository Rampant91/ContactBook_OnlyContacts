using MyContactBook.DbRealization;
using MyContactBook.Models;
using MyContactBook.ViewModels;
using System.ComponentModel;
using System.Linq;

namespace MyContactBook.Commands
{
    public class UpdateContactCommand : BaseCommand
    {
        private readonly ContactsViewModel _contactsViewModel;

        public UpdateContactCommand(ContactsViewModel contactViewMode)
        {
            _contactsViewModel = contactViewMode;
            _contactsViewModel.PropertyChanged += ContactsViewModelPropertyChanged;
        }

        private void ContactsViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ContactsViewModel.SelectedContact))
            {
                OnCanExecuteChanged();
            }
            if (e.PropertyName == nameof(ContactsViewModel.FirstName))
            {
                OnCanExecuteChanged();
            }
            if (e.PropertyName == nameof(ContactsViewModel.LastName))
            {
                OnCanExecuteChanged();
            }
            if (e.PropertyName == nameof(ContactsViewModel.Patronymic))
            {
                OnCanExecuteChanged();
            }
            if (e.PropertyName == nameof(ContactsViewModel.Phone))
            {
                OnCanExecuteChanged();
            }
            if (e.PropertyName == nameof(ContactsViewModel.Email))
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
            using (DataContext db = new DataContext())
            {
                var contact = _contactsViewModel.SelectedContact;
                var contactDb = db.Contacts.FirstOrDefault(x => x.Id == contact.Id);
                if (contactDb != null)
                {
                    contactDb.FirstName = contact.FirstName;
                    contactDb.LastName = contact.LastName;
                    contactDb.Patronymic = contact.Patronymic;
                    contactDb.Phone = contact.Phone;
                    contactDb.Email = contact.Email;
                    db.SaveChanges();
                }
                //_contactsViewModel.Editable = false;
            }
        }
    }
}
