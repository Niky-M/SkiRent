using SkiRent.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace SkiRent
{
    public partial class OrderWindow : Window
    {
        float price;
        string skiId, bootId, sticksId;
        int? skiDb, bootDb, sticksDb;
        bool skiFound = false; // нашли ли подходящие лыжи
        bool bootFound = false;
        bool stickFound = false;
        ObservableCollection<Level> levelCollection;
        ObservableCollection<Order> orderCollection;
        public ObservableCollection<Level> Levels
        {
            get => levelCollection;
            set
            {
                levelCollection = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Order> Orders
        {
            get => orderCollection;
            set
            {
                orderCollection = value;
                OnPropertyChanged();
            }
        }
        public OrderWindow()
        {
            LoadLevels();
            InitializeComponent();
            skiLevel.Text = "новичок";
            bootsLevel.Text = "новичок";
            sticksLevel.Text = "новичок";
            bracing.Text = "SNS";
            rentTime.Text = "1 час";
        }

        private void calculateButtonClick(object sender, RoutedEventArgs e) //расчет стоимости проката
        {
            //double price = 0;
            int skiPrice = 0;
            int bootsPrice = 0;
            int sticksPrice = 0;
            priceLabel.Text = "Price: ";
            date.Text = "Date and Time: " + DateTime.Now;


            if (skiLevel.Text == "none") skiPrice = 0;
            if (skiLevel.Text == "новичок") skiPrice = 200;
            if (skiLevel.Text == "продвинутый") skiPrice = 300;
            if (skiLevel.Text == "профи") skiPrice = 400;

            if (bootsLevel.Text == "none") bootsPrice = 0;
            if (bootsLevel.Text == "новичок") bootsPrice = 150;
            if (bootsLevel.Text == "продвинутый") bootsPrice = 200;
            if (bootsLevel.Text == "pro") bootsPrice = 300;

            if (sticksLevel.Text == "none") sticksPrice = 0;
            if (sticksLevel.Text == "новичок") sticksPrice = 50;
            if (sticksLevel.Text == "продвинутый") sticksPrice = 100;


            price = skiPrice + bootsPrice + sticksPrice;

            if (rentTime.Text == "2 hours") price *= 1.7F;
            if (rentTime.Text == "3 hours") price *= 2.4F;
            if (rentTime.Text == "day") price *= 10;

            if (price == 0)
            {
                MessageBox.Show("Оборудование не выбранно!");
                return;
            }

            priceLabel.Text += Convert.ToString(price);
        }
        private void ButtonComplectClick(object sender, RoutedEventArgs e)
        {
            int skiLength = 0; // переменная для подбора лыж по длине
            int stickLength = 0;
      
            if (style.Text == "skate")
            {
                skiLength = Convert.ToInt32(heightTb.Text) + 15;
                stickLength = Convert.ToInt32(heightTb.Text) - 10;
            }
            else if (style.Text == "classic")
            {
                skiLength = Convert.ToInt32(heightTb.Text) + 25;
                stickLength = Convert.ToInt32(heightTb.Text) - 20;
            }

            SqlConnection con = new SqlConnection(@"data source=(localdb)\MSSQLLocalDB; Initial Catalog = SkiRent02; Integrated Security=True;");
            con.Open();

            string skiLevelQuery = $"Select LevelId from Level where LevelName = N'{skiLevel.Text}'";
            SqlCommand commandSkiLevel = new SqlCommand(skiLevelQuery, con);
            SqlDataReader readerSkiLevel = commandSkiLevel.ExecuteReader();
            readerSkiLevel.Read();
            string skiLevelValue = Convert.ToString(readerSkiLevel.GetValue(0));
            readerSkiLevel.Close();
            string bootLevelQuery = $"Select LevelId from Level where LevelName = N'{bootsLevel.Text}'";
            SqlCommand commandBootLevel = new SqlCommand(bootLevelQuery, con);
            SqlDataReader readerBootLevel = commandBootLevel.ExecuteReader();
            readerBootLevel.Read();
            string bootLevelValue = Convert.ToString(readerBootLevel.GetValue(0));
            readerBootLevel.Close();
            string stickLevelQuery = $"Select LevelId from Level where LevelName = N'{sticksLevel.Text}'";
            SqlCommand commandStickLevel = new SqlCommand(stickLevelQuery, con);
            SqlDataReader readerStickLevel = commandStickLevel.ExecuteReader();
            readerStickLevel.Read();
            string stickLevelValue = Convert.ToString(readerStickLevel.GetValue(0));
            readerStickLevel.Close();

            // подбор лыж по длине

            for (int i = skiLength; i >= skiLength - 15; i--)
            {
                string querySki = $"Select SkiId, Length, Brand from Ski where  Style = '{style.Text}' and Length = '{i}' /*and Weight = '{weightTb.Text}'*/ and Bracing = '{bracing.Text}' and LevelId = '{skiLevelValue}'";
                SqlCommand command = new SqlCommand(querySki, con);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows) // проверка на наличие подходящих лыж
                {
                    reader.Read();
                    skiId = Convert.ToString(reader.GetValue(0)); // так же вытащить остальные данные и найти спосоьб получше   
                    string foundSkiLength = Convert.ToString( reader.GetValue(1));
                    string foundSkiLabel = // нати способ вытащить бренд
                    skiLabel.Text = "Лыжи" + skiId + ' ' + foundSkiLength + 'm';
                    skiFound = true;
                    reader.Close();
                    break;
                }
                reader.Close();
            }
            // если лыжи не нашли
            if (skiFound == false)
                skiLabel.Text = " not found!";

            // подбор ботинок
            string queryBoots = $"Select BootId from Boot where  Style = '{style.Text}' and Size = '{sizeTb.Text}' and Bracing = '{bracing.Text}' and LevelId = '{bootLevelValue}'";
            SqlCommand command2 = new SqlCommand(queryBoots, con);
            SqlDataReader reader2 = command2.ExecuteReader();
            if (reader2.HasRows)
            {
                reader2.Read();
                bootId = Convert.ToString(reader2.GetValue(0));
                bootsLabel.Text = "Ботинки: " + bootId;
                bootFound = true;
            }
            if (bootFound == false)
                bootsLabel.Text = "Boots not found!";
            reader2.Close();

            // подбор палок
            for (int i = stickLength; i >= stickLength - 5; i--)
            {
                string querySticks = $"Select StickId from Stick where Length = '{i}' and LevelId = '{stickLevelValue}'";
                SqlCommand command3 = new SqlCommand(querySticks, con);
                SqlDataReader reader3 = command3.ExecuteReader();
                if (reader3.HasRows)
                {
                    reader3.Read();
                    sticksId = Convert.ToString(reader3.GetValue(0));
                    sticksLabel.Text = "Палки: " + sticksId;
                    stickFound = true;
                    break;
                }
                reader3.Close();
            }

            if (stickFound == false)
                sticksLabel.Text = "Sticks not foutnd!";
        }

        private void checkoutButtonClick(object sender, RoutedEventArgs e)
        {
            if (Convert.ToString(priceLabel.Text) == "Цена: ")
            {
                MessageBox.Show("You didn't calculate!");
                return;
            }

            SqlConnection con = new SqlConnection(@"data source=(localdb)\MSSQLLocalDB; Initial Catalog = SkiRent02; Integrated Security=True;");
            con.Open();

            string LevelQuery = $"Select ClientId from Client where Name = N'{name.Text}'";
            SqlCommand commandLevel = new SqlCommand(LevelQuery, con);
            SqlDataReader reader = commandLevel.ExecuteReader();
            reader.Read();

            if (skiFound == false)
                skiDb = null;
            else
                skiDb = Convert.ToInt32(skiId);

            if (bootFound == false)
                bootDb = null;
            else
                bootDb = Convert.ToInt32(bootId);

            if (stickFound == false)
                sticksDb = null;
            else
                sticksDb = Convert.ToInt32(sticksId);


            var db = new SkiRent02Context();
            {
                var order = new Order()
                {
                    ClientId = Convert.ToInt32(reader.GetValue(0)),
                    SkiId = Convert.ToInt32(skiId),
                    BootId = Convert.ToInt32(bootId),
                    StickId = Convert.ToInt32(sticksId),
                    Price = price,
                    Status = "active",
                    Data = DateTime.Now
                };

                db.Orders.Add(order);
                db.SaveChanges();
                Close();
                LoadOrders();     
            };
        }

        //-------------------------------------------------------------------
        private void LoadLevels()
        {
            DataContext = this;
            using var context = new SkiRent02Context();
            Levels = new ObservableCollection<Level>(context.Levels.ToList());
        }

        private void LoadOrders()
        {
            DataContext = this;
            using var context = new SkiRent02Context();
            Orders = new ObservableCollection<Order>(context.Orders.ToList());
        }

        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void addCustomerClick(object sender, RoutedEventArgs e)
        {
            var sp = new StackPanel();
            sp.Children.Add(new Button());
            sv.Content = sp;
        }
    }
}
