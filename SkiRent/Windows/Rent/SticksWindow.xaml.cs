using SkiRent.Models;
using SkiRent.Windows.Rent;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace SkiRent
{
    public partial class SticksWindow : Window, INotifyPropertyChanged
    {
        ObservableCollection<Stick> sticksCollection;
        public ObservableCollection<Stick> Sticks
        {
            get => sticksCollection;
            set
            {
                sticksCollection = value;
                OnPropertyChanged();
            }
        }

        ObservableCollection<Brand> brandCollection;
        ObservableCollection<Level> levelCollection;
        public ObservableCollection<Brand> Brands
        {
            get => brandCollection;
            set
            {
                brandCollection = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Level> Levels
        {
            get => levelCollection;
            set
            {
                levelCollection = value;
                OnPropertyChanged();
            }
        }

        public SticksWindow()
        {
            LoadSticks();
            LoadBrands();
            LoadLevels();
            InitializeComponent();
        }

        private void WindowLoad(object sender, RoutedEventArgs e)
        {
            LoadSticks();
        }

        private void ButtonAddClick(object sender, RoutedEventArgs e)
        {
            int result;
            if (String.IsNullOrEmpty(lengthTb.Text) || !Int32.TryParse(lengthTb.Text, out result) || Convert.ToInt32(lengthTb.Text) < 80 || Convert.ToInt32(lengthTb.Text) > 200)
            {
                MessageBox.Show("Length has to be an integer number from 80 to 200!");
                return;
            }

            SqlConnection con = new SqlConnection(@"data source=(localdb)\MSSQLLocalDB; Initial Catalog = SkiRent02; Integrated Security = True;");
            string brandQuery = $"Select BrandId from Brand where BrandName = '{brand.Text}'";
            string levelQuery = $"Select LevelId from Level where LevelName = N'{level.Text}'";
            con.Open();

            SqlCommand commandBrand = new SqlCommand(brandQuery, con);
            SqlCommand commandLevel = new SqlCommand(levelQuery, con);

            SqlDataReader readerBrand = commandBrand.ExecuteReader();
            readerBrand.Read();
            int BrandIdValue = Convert.ToInt32(readerBrand.GetValue(0));
            readerBrand.Close();

            SqlDataReader readerLevel = commandLevel.ExecuteReader();
            readerLevel.Read();
            int LevelIdValue = Convert.ToInt32(readerLevel.GetValue(0));
            readerLevel.Close();

            var db = new SkiRent02Context();
            var stick = new Stick()
            {
                BrandId = BrandIdValue,
                Length = Convert.ToInt32(lengthTb.Text),
                LevelId = LevelIdValue
            };
            db.Sticks.Add(stick);
            db.SaveChanges();
            LoadSticks();
        }
        private void LoadSticks() // разобрать
        {
            DataContext = this;
            using var context = new SkiRent02Context();
            Sticks = new ObservableCollection<Stick>(context.Sticks
                .Include(brand => brand.Brand)
                .Include(level => level.Level)
                .ToList());
        }
        private void LoadBrands()
        {
            DataContext = this;
            using var context = new SkiRent02Context();
            Brands = new ObservableCollection<Brand>(context.Brands.ToList());
        }
        private void LoadLevels()
        {
            DataContext = this;
            using var context = new SkiRent02Context();
            Levels = new ObservableCollection<Level>(context.Levels.ToList());
        }

        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        //---------------------------------------------------------------------------------



        private void ButtonServiceClick(object sender, RoutedEventArgs e)
        {
            var service = new ServiceWindow();
            service.Show();
            Close();
        }
        private void ButtonTrainsClick(object sender, RoutedEventArgs e)
        {

        }
        private void ButtonProfitClick(object sender, RoutedEventArgs e)
        {

        }
        /////////////////////////////////////////////////////////////////////////////////////////
        private void ButtonRentClick(object sender, RoutedEventArgs e)
        {
            RentWindow main = new RentWindow();
            main.Show();
        }
        private void ButtonSkiClick(object sender, RoutedEventArgs e)
        {
            SkiWindow ski = new SkiWindow();
            ski.Show();
            Close();
        }
        private void ButtonBootsClick(object sender, RoutedEventArgs e)
        {
            BootsWindow boot = new BootsWindow();
            boot.Show();
            Close();
        }
        private void ButtonClientClick(object sender, RoutedEventArgs e)
        {
            ClientsWindow clients = new ClientsWindow();
            clients.Show();
            Close();
        }
        private void ButtonEmployeeClick(object sender, RoutedEventArgs e)
        {
            EmployeeWindow employee = new EmployeeWindow();
            employee.Show();
            Close();
        }
        private void ButtonSettingsClick(object sender, RoutedEventArgs e)
        {
            SettingsWindow set = new SettingsWindow();
            set.Show();
            Close();
        }

        private void ButtonReservationClick(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonDepozitClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
