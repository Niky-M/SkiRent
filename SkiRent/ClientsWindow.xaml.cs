using SkiRent.Models;
using SkiRent.Windows.Rent;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace SkiRent
{
    public partial class ClientsWindow : Window, INotifyPropertyChanged 
    {
        ObservableCollection<Client> ClientsCollection;
        public ObservableCollection<Client> Clients // { get; set; }
        {
            get => ClientsCollection;
            set
            {
                ClientsCollection = value;
                OnPropertyChanged();
            }
        }

        void ButtonAddClick(object sender, RoutedEventArgs e)
        {

            int result;
            Int64 phonResult;
            if (String.IsNullOrEmpty(newClientPhone.Text)
                || !Int64.TryParse(newClientPhone.Text, out phonResult)
                || Convert.ToInt64(newClientPhone.Text) < 10000000000
                || Convert.ToInt64(newClientPhone.Text) >= 100000000000)
            {
                MessageBox.Show("Phone has to be an integer number consisting of 11 figures!");
                return;
            }
            if (String.IsNullOrEmpty(newClientHeight.Text)
                || !Int32.TryParse(newClientHeight.Text, out result)
                || Convert.ToInt32(newClientHeight.Text) < 80
                || Convert.ToInt32(newClientHeight.Text) > 250)
            {
                MessageBox.Show("Height has to be an integer number from 80 to 250!");
                return;
            }

            if (String.IsNullOrEmpty(newClientWeight.Text)
                || !Int32.TryParse(newClientWeight.Text, out result)
                || Convert.ToInt32(newClientWeight.Text) < 20
                || Convert.ToInt32(newClientWeight.Text) > 150)
            {
                MessageBox.Show("Weight has to be an integer number from 20 to 150!");
                return;
            }
            if (String.IsNullOrEmpty(newClientSize.Text)
                || !Int32.TryParse(newClientSize.Text, out result)
                || Convert.ToInt32(newClientSize.Text) < 24
                || Convert.ToInt32(newClientSize.Text) > 47)
            {
                MessageBox.Show("size has to be an integer number!");
                return;
            }

            var db = new SkiRent02Context();
            var client = new Client()
            {
                Name = newClientName.Text,
                Phone = Convert.ToInt64(newClientPhone.Text),
                Height = Convert.ToInt32(newClientHeight.Text),
                Weight = Convert.ToInt32(newClientWeight.Text),
                Size = Convert.ToInt32(newClientSize.Text),
                Login = newClientName.Text,
                Password = newClientPhone.Text
            };
            db.Clients.Add(client);
            db.SaveChanges();
            LoadClients();
        }
        
        public static Client SelectedClient { get; set; }

        public ClientsWindow()
        {
            InitializeComponent();
            LoadClients();
        }
       
        //----------------------------------------------------------------------
        
        private void LoadClients()
        {
            DataContext = this;
            using var context = new SkiRent02Context();
            Clients = new ObservableCollection<Client>(context.Clients.ToList());
        }
        private void ButtonDeleteClick(object sender, RoutedEventArgs e)
        {
            try
            {
                using var context = new SkiRent02Context();
                context.Entry(SelectedClient).State = EntityState.Deleted;
                context.SaveChanges();
                LoadClients();
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message);
            }
        }
        private void ButtonChangeClick(object sender, RoutedEventArgs e)
        {
            var changeClientInfo = new ChangeClientInfo();
            changeClientInfo.ShowDialog();
            LoadClients();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        //-------------------------------------------------------------------------
        // меню
        public void ButtonRentClick(object sender, RoutedEventArgs e)
        {
            RentWindow main = new RentWindow();
            main.Show();
            Close();
        }
        private void ButtonServiceClick(object sender, RoutedEventArgs e)
        {
            var service = new ServiceWindow();
            service.Show();
            Close();
        }
        private void ButtonTrainsClick(object sender, RoutedEventArgs e)
        {

        }
        private void ButtonEmployeeClick(object sender, RoutedEventArgs e)
        {
            var emp = new EmployeeWindow();
            emp.Show();
            Close();
        }
        private void ButtonProfitClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
