using System;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using SkiRent.Models;
using SkiRent.Windows.Training;

namespace SkiRent.Windows.Rent
{
    public partial class RentWindow : Window
    {
        //ObservableCollection<DbClient> clientCollection = null;
        ObservableCollection<Order> orderCollection;
        ObservableCollection<Client> clientCollection;
        ObservableCollection<Stuff> stuffCollection;
        public ObservableCollection<Order> Orders
        {
            get => orderCollection;
            set
            {
                orderCollection = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Client> Clients
        {
            get => clientCollection;
            set
            {
                clientCollection = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Stuff> Stuff
        {
            get => stuffCollection;
            set
            {
                stuffCollection = value;
                OnPropertyChanged();
            }
        }
        public static Order SelectedOrder {get;set;}
        public RentWindow()
        {
            LoadOrders();
            LoadClients();
            LoadStuff();
            InitializeComponent();
        }
        public void ConfirmName(object sender, RoutedEventArgs e)
        {
            if (fio.Text == null || fio.Text == "") //проверка на пустое имя
                MessageBox.Show("Укажите имя гостя!");
            else
            { //проверка на наличие имени в базе данных
                SqlConnection sqlcon = new SqlConnection(@"data source=(localdb)\MSSQLLocalDB; Initial Catalog = SkiRent02; Integrated Security=True;");
                //DbSkiRent db = new DbSkiRent();
                string query = $"Select Name, Height, Weight, Size as 'EqualWithSpace' from Client where Name = N'{fio.Text}'";

                SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);

                if (dtbl.Rows.Count == 1)
                {//открываем окно оформления заказа и передаем туда имя клиента
                    OrderWindow orderWindow = new OrderWindow();
                    orderWindow.Show();

                    sqlcon.Open();
                    SqlCommand cammand = new SqlCommand(query, sqlcon);
                    SqlDataReader reader = cammand.ExecuteReader();
                    reader.Read();

                    //var client = new DbClient();
                    orderWindow.name.Text = Convert.ToString(reader.GetValue(0));
                    orderWindow.heightTb.Text = Convert.ToString(reader.GetValue(1));
                    orderWindow.weightTb.Text = Convert.ToString(reader.GetValue(2));
                    orderWindow.sizeTb.Text = Convert.ToString(reader.GetValue(3));

                    reader.Close();
                    //Close();
                }
                else
                {
                    NewClient newClient = new NewClient();
                    newClient.Show();
                    newClient.name.Text = fio.Text;
                }
            }
        }

        private void LoadOrders()
        {
            DataContext = this;
            using var context = new SkiRent02Context();
            Orders = new ObservableCollection<Order>(context.Orders
                .Include(client => client.Client)
                .Include(ski => ski.Ski)
                .Include(boots => boots.Boot)
                .Include(sticks => sticks.Stick)
                .ToList());
        }
        private void LoadClients()
        {
            DataContext = this;
            using var context = new SkiRent02Context();
            Clients = new ObservableCollection<Client>(context.Clients.ToList());
        }

        private void LoadStuff()
        {
            DataContext = this;
            using var context = new SkiRent02Context();
            Stuff = new ObservableCollection<Stuff>(context.Stuffs.ToList());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //-----------кнопки------------------------------------------------
        private void ButtonAddClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("добавить клиента");
        }
        private void ToMenueButton(object sender, RoutedEventArgs e)
        {
            var menue = new MainWindow();
            menue.Show();
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
            var emp = new EmployeeWindow();
            emp.Show();
            Close();
        }
        private void ButtonClientsClick(object sender, RoutedEventArgs e)
        {
            ClientsWindow clients = new ClientsWindow();
            clients.Show();
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
        private void ButtonProfitClick(object sender, RoutedEventArgs e)
        {

        }
        private void ButtonDepozitClick(object sender, RoutedEventArgs e)
        {

        }

        

        //private void client_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    string mainconn = ConfigurationManager.ConnectionStrings["SkiRent"].ConnectionString;
        //    SqlConnection sqlconn = new SqlConnection(mainconn);
        //    string sqlquery = "select Name, Phone, Price, Data from Orders inner join Clients on Orders.OrderId = Clients";
        //    SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
        //    sqlconn.Open();
        //    SqlDataAdapter sda = new SqlDataAdapter(sqlcomm);
        //    DataTable dt = new DataTable();
        //    sda.Fill(dt);
        //    //clientDG.ItemsSource = dt;
        //    //clientDG.Binding
        //    sqlconn.Close();

        //}
    }
}