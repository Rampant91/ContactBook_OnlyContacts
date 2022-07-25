using ContactBook_OnlyContacts.ViewModels;
using System.ComponentModel;

namespace ContactBook_OnlyContacts.Commands
{
    public class EditContactCommand : BaseCommand
    {
        private readonly ContactsViewModel _contactsViewModel;

        public EditContactCommand(ContactsViewModel contactsViewModel)
        {
            _contactsViewModel = contactsViewModel;
            _contactsViewModel.PropertyChanged += ContactsViewModelPropertyChanged;
        }

        private void ContactsViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ContactsViewModel.SelectedContact)
                || e.PropertyName == nameof(ContactsViewModel.SelectedContact.Editable))
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
            _contactsViewModel.Editable = true;
        }
    }
}