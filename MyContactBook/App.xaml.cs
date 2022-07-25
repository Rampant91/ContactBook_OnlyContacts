using ContactBook_OnlyContacts.ViewModels;
using System.Windows;

namespace ContactBook_OnlyContacts
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs args)
        {
            var MainWindow = new MainWindow()
            {
                DataContext = new ContactsViewModel()
            };
            MainWindow.Show();
        }
    }
}