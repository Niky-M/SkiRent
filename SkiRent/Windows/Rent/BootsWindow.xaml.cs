using SkiRent.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
//using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using Microsoft.EntityFrameworkCore;

namespace SkiRent.Windows.Rent
{

    public partial class BootsWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<Boot> bootsCollection;
        public ObservableCollection<Boot> Boots
        {
            get => bootsCollection;
            set
            {
                bootsCollection = value;
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

        public BootsWindow()
        {
            LoadBoots();
            LoadBrands();
            LoadLevels();
            InitializeComponent();
        }
        //private void WindowLoad(object sender, RoutedEventArgs e)
        //{
        //    LoadBoots();
        //}
        private void ButtonAddClick(object sender, RoutedEventArgs e)
        {
            //проверка введеных данных
            int result;
            if (String.IsNullOrEmpty(sizeTb.Text) || !Int32.TryParse(sizeTb.Text, out result) || Convert.ToInt32(sizeTb.Text) < 25 || Convert.ToInt32(sizeTb.Text) > 50)
            {
                MessageBox.Show("Size has to be an integer number from 25 to 50!");
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
            var boot = new Boot()
            {
                BrandId = BrandIdValue,
                Style = style.Text,
                Size = Convert.ToInt32(sizeTb.Text),
                Bracing = bracing.Text,
                LevelId = LevelIdValue
            };
            db.Boots.Add(boot);
            db.SaveChanges();
            LoadBoots();
        }
        //------------------------------------------------------------------------------
        // коллекции
        private void LoadBoots()
        {
            DataContext = this;
            using var context = new SkiRent02Context();
            Boots = new ObservableCollection<Boot>(context.Boots
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
        //////////////////////////////////////////////////////////////////////////
        // верзние кнопки
        private void ButtonServiceClick(object sender, RoutedEventArgs e)
        {
            var service = new ServiceWindow();
            service.Show();
            Close();
        }
        private void ButtonTrainsClick(object sender, RoutedEventArgs e)
        {

        }
        private void ButtonClientsClick(object sender, RoutedEventArgs e)
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
        private void ButtonProfitClick(object sender, RoutedEventArgs e)
        {

        }
        //////////////////////////////////////////////////////////////////////////////
        // нижние кнопки
        private void ButtonSkiClick(object sender, RoutedEventArgs e)
        {
            SkiWindow ski = new SkiWindow();
            ski.Show();
            Close();
        }
        private void ButtonSticksClick(object sender, RoutedEventArgs e)
        {
            SticksWindow sticks = new SticksWindow();
            sticks.Show();
            Close();
        }
        private void ButtonRentClick(object sender, RoutedEventArgs e)
        {
            RentWindow main = new RentWindow();
            main.Show();
            Close();
        }
        private void ButtonSettingsClick(object sender, RoutedEventArgs e)
        {
            SettingsWindow set = new SettingsWindow();
            set.Show();
            Close();
        }

        private void ButtonDepozitClick(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonReservationClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
