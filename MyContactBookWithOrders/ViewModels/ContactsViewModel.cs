using MyContactBookWithOrders.DbRealization;
using MyContactBookWithOrders.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace MyContactBookWithOrders.ViewModels
{
    public class ContactsViewModel : BaseViewModel
    {
        #region ObservableCollections
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

        private ObservableCollection<Order> _orders;
        public ObservableCollection<Order> Orders
        {
            get => _orders;
            set
            {
                _orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }
        #endregion

        #region SelectedItems
        private Contact _selectedContact;
        public Contact SelectedContact
        {
            get => _selectedContact;
            set
            {
                if (_selectedContact != value)
                {
                    _selectedContact = value;

                    using (DataContext dataContext = new DataContext())
                    {
                        var orders = dataContext.Orders.Where(x => x.ContactId == SelectedContact.Id);
                        Orders = new ObservableCollection<Order>(orders);
                    }
                    OnPropertyChanged(nameof(SelectedContact));
                }
            }
        }

        private Order _selectedOrder;
        public Order SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                _selectedOrder = value;
                Date = _selectedOrder.Date;
                Price = _selectedOrder.Price;
                Name = _selectedOrder.Name;
                OnPropertyChanged(nameof(SelectedOrder));
            }
        }
        #endregion

        #region OrderProperties
        private int _price;
        public int Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        private int _date;
        public int Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        #endregion

        #region Constructor
        public ContactsViewModel()
        {
            using (DataContext db = new DataContext())
            {
                Contacts = new ObservableCollection<Contact>(db.Contacts.ToList());
            }
        }
        #endregion
    }
}