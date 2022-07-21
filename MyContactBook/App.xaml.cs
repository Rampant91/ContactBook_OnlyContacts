using MyContactBook.ViewModels;
using System.Windows;

namespace MyContactBook
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
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
