using SkiRent.Models;
using SkiRent.Windows.Rent;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace SkiRent
{
    public partial class SettingsWindow : Window, INotifyPropertyChanged
    {
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

        private void LoadBrands()
        {
            DataContext = this;
            using var context = new SkiRent02Context();
            brandCollection = new ObservableCollection<Brand>(context.Brands.ToList());
        }
        private void LoadLevels()
        {
            DataContext = this;
            using var context = new SkiRent02Context();
            levelCollection = new ObservableCollection<Level>(context.Levels.ToList());
        }
        public SettingsWindow()
        {
            LoadBrands();
            LoadLevels();
            InitializeComponent();
        }
        private void WindowLoad (object sender, RoutedEventArgs e)
        {
            LoadBrands();
            LoadLevels();
        }
        private void ButtonAddBrandClick(object sender, RoutedEventArgs e)
        {
            var context = new SkiRent02Context();
            {
                if (addBrand.Content == "Добавить")
                {
                    var brand = new Brand()
                    {
                        BrandName = tbBrand.Text
                    };
                    context.Brands.Add(brand);
                }
                if (addBrand.Content == "Изменить")
                {
                    SelectedBrand.BrandName = tbBrand.Text;
                    context.Entry(SelectedBrand).State = EntityState.Modified;
                    tbBrand.Text = "";
                    addBrand.Content = "Добавить";
                }
                else
                {
                    var brand = new Brand()
                    {
                        BrandName = tbBrand.Text
                    };
                    context.Brands.Add(brand);
                }
            }
            context.SaveChanges();
            tbBrand.Text = "";
            LoadBrands();
        }
        public static Level SelectedLevel { get; set; }
        public static Brand SelectedBrand { get; set; }
        private void ButtonAddLevelClick(object sender, RoutedEventArgs e)
        {
            var context = new SkiRent02Context();
            {
                if (addLevel.Content == "Изменить")
                {
                    SelectedLevel.LevelName = tbLevel.Text;
                    context.Entry(SelectedLevel).State = EntityState.Modified;
                    tbLevel.Text = "";
                    addLevel.Content = "Добавить";
                }
                else
                {
                    var level = new Level()
                    {
                        LevelName = tbLevel.Text
                    };
                    context.Levels.Add(level);
                }
            }
            
            context.SaveChanges();
            tbLevel.Text = "";
            LoadLevels(); 
        }

        private void OptionChangeLevelClick(object sender, RoutedEventArgs e)
        {
            tbLevel.Text = SelectedLevel.LevelName;
            addLevel.Content = "Изменить";
        }
        private void OptionDeleteLevelClick(object sender, RoutedEventArgs e)
        {
            using var context = new SkiRent02Context();
            context.Entry(SelectedLevel).State = EntityState.Deleted;
            context.SaveChanges();
            LoadLevels();
        }

        private void OptionChangeBrandClick(object sender, RoutedEventArgs e)
        {
            tbBrand.Text = SelectedBrand.BrandName;
            addBrand.Content = "Изменить";
        }
        private void OptionDeleteBrandClick(object sender, RoutedEventArgs e)
        {
            using var context = new SkiRent02Context();
            context.Entry(SelectedBrand).State = EntityState.Deleted;
            context.SaveChanges();
            LoadBrands();
        }

        //------------------------------------------------------------------------------------------
        // 1 меню
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
            MessageBox.Show("profit");
        }

        //--------------------------------------------------------------------------------
        // 2 меню
        private void ButtonRentClick(object sender, RoutedEventArgs e)
        {
            RentWindow rent = new RentWindow();
            rent.Show();
            Close();
        }
        private void ButtonClientsClick(object sender, RoutedEventArgs e)
        {
            ClientsWindow clients = new ClientsWindow();
            clients.Show();
            Close();
        }
        private void ButtonEquipmentClick(object sender, RoutedEventArgs e)
        {
            SkiWindow equip = new SkiWindow();
            equip.Show();
            Close();
        }
        private void ButtonEmployeesClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("сотрудники");
        }
        private void ButtonReservationClick(object sender, RoutedEventArgs e)
        {

        }
        private void ButtonDepozitClick(object sender, RoutedEventArgs e)
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void LevelName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
