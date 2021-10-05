using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Collections.ObjectModel;
using SkiRent.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace SkiRent.Windows.Rent
{
    public partial class SkiWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<Ski> skiCollection;
        public ObservableCollection<Ski> Ski
        {
            get => skiCollection;
            set
            {
                skiCollection = value;
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
        public static Ski SelectedSki { get; set; }

        public SkiWindow()
        {
            LoadSki();
            LoadBrands();
            LoadLevels();
            InitializeComponent();
        }
        private void WindowLoad(object sender, RoutedEventArgs e)
        {
            LoadSki();
        }
        private void ButtonAddClick(object sender, RoutedEventArgs e)
        {
            //проверка введеных данных
            int result;
            if (String.IsNullOrEmpty(lengthTb.Text) || !Int32.TryParse(lengthTb.Text, out result) || Convert.ToInt32(lengthTb.Text) < 80 || Convert.ToInt32(lengthTb.Text) > 250)
            {
                MessageBox.Show("Length has to be an integer number from 80 to 250!");
                return;
            }

            if (String.IsNullOrEmpty(weightTb.Text) || !Int32.TryParse(weightTb.Text, out result) || Convert.ToInt32(weightTb.Text) < 20 || Convert.ToInt32(weightTb.Text) > 150)
            {
                MessageBox.Show("Weight has to be an integer number from 20 to 150!");
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
            var brands = new Brand();
            var ski = new Ski()
            {
                BrandId = BrandIdValue,
                LevelId = LevelIdValue,
                Style = style.Text,
                Length = Convert.ToInt32(lengthTb.Text),
                Weight = Convert.ToInt32(weightTb.Text),
                Bracing = brasing.Text,
            };
            db.Skis.Add(ski);
            db.SaveChanges();
            LoadSki();
        }

        private void ButtonDeleteClick(object sender, RoutedEventArgs e)
        {
            try
            {
                using var context = new SkiRent02Context();
                context.Entry(SelectedSki).State = EntityState.Deleted;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }
        }

        private void LoadSki() // разобрать
        {
            DataContext = this;
            using var context = new SkiRent02Context();
            Ski = new ObservableCollection<Ski>(context.Skis
                .Include(brand => brand.Brand)
                .Include(level => level.Level)
                .ToList());
        }

        //------------------------------------------------------------
        private void ButtonServiceClick(object sender, RoutedEventArgs e)
        {
            var service = new ServiceWindow();
            service.Show();
            Close();
        }
        private void ButtonTrainsClick(object sender, RoutedEventArgs e)
        {

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
        private void ButtonProfitClick(object sender, RoutedEventArgs e)
        {

        }
        ////////////////////////////////////////////////////////////////////////////
        
        private void ButtonRentClick(object sender, RoutedEventArgs e)
        {
            RentWindow main = new RentWindow();
            main.Show();
            Close();
        }
        private void ButtonBootsClick(object sender, RoutedEventArgs e)
        {
            BootsWindow boot = new BootsWindow();
            boot.Show();
            Close();
        }
        private void ButtonSticksClick(object sender, RoutedEventArgs e)
        {
            SticksWindow stick = new SticksWindow();
            stick.Show();
            Close();
        }
        private void ButtonReservationClick(object sender, RoutedEventArgs e)
        {

        }
        private void ButtonDepozitClick(object sender, RoutedEventArgs e)
        {

        }
        private void ButtonSettingsClick(object sender, RoutedEventArgs e)
        {
            SettingsWindow set = new SettingsWindow();
            set.Show();
            Close();
        }
        
        //--------------------------------------------------------------------------
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

    }
}
