using ContactBook_OnlyContacts.DbRealization;
using ContactBook_OnlyContacts.ViewModels;
using System.ComponentModel;
using System.Linq;

namespace ContactBook_OnlyContacts.Commands
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
            if (e.PropertyName == nameof(ContactsViewModel.SelectedContact)
                || e.PropertyName == nameof(ContactsViewModel.FirstName)
                || e.PropertyName == nameof(ContactsViewModel.LastName)
                || e.PropertyName == nameof(ContactsViewModel.Patronymic)
                || e.PropertyName == nameof(ContactsViewModel.Phone)
                || e.PropertyName == nameof(ContactsViewModel.Email))
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
                var contact = _contactsViewModel.SelectedContact = null!;
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
                _contactsViewModel.Editable = false;
            }
        }
    }
}