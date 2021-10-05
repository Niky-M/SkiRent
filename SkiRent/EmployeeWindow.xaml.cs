using SkiRent.Models;
using SkiRent.Windows.Rent;
using SkiRent.Windows.Training;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace SkiRent
{
    public partial class EmployeeWindow : Window
    {
        ObservableCollection<Stuff> stuffCollection;
        public ObservableCollection<Stuff> Stuffs
        {
            get => stuffCollection;
            set
            {
                stuffCollection = value;
                OnPropertyChanged();
            }
        }
        public EmployeeWindow()
        {
            InitializeComponent();
            LoadStuff();
        }
        private void LoadStuff()
        {
            DataContext = this;
            using var context = new SkiRent02Context();
            Stuffs = new ObservableCollection<Stuff>(context.Stuffs.ToList());
        }
        private void ButtonAddClick(object sender, RoutedEventArgs e)
        {
            var db = new SkiRent02Context();
            var stuff = new Stuff()
            {
                Name = stuffName.Text,
                Password = password.Text,
                Phone = Convert.ToInt64(stuffPhone.Text)
            };
            db.Stuffs.Add(stuff);
            db.SaveChanges();
        }
        //-----------------------------------------------------------------------
        // меню
        private void ButtonRentClick(object sender, RoutedEventArgs e)
        {
            var rent = new RentWindow();
            rent.Show();
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
            var train = new TrainingWindow();
            train.Show();
            Close();
        }
        private void ButtonClientsClick(object sender, RoutedEventArgs e)
        {
            var client = new ClientsWindow();
            client.Show();
            Close();
        }
        private void ButtonProfitClick(object sender, RoutedEventArgs e)
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
