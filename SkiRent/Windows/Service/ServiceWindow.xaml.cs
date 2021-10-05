using SkiRent.Windows.Rent;
using SkiRent.Windows.Training;
using System.Windows;

namespace SkiRent
{
    public partial class ServiceWindow : Window
    {
        public ServiceWindow()
        {
            InitializeComponent();
        }

        private void Confirm(object sender, RoutedEventArgs e)
        {
            //var con = new SkiRent02Context();
            //var serv = new Service();
            //{
            //    Name = name.Text;
            //    St
            //}
        }

        //-----------------------------------------------------------------
        // верхнее меню
        private void ButtonRentClick(object sender, RoutedEventArgs e)
        {
            var rent = new RentWindow();
            rent.Show();
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


        // нужно ли это окно?
        //private void ButtonEquipmentClick(object sender, RoutedEventArgs e)
        //{
        //    var equip = new EquipmentWindow();
        //    equip.Show();
        //    Close();
        //}
        private void ButtonReservationClick(object sender, RoutedEventArgs e)
        {

        }
        private void ButtonClientsClick(object sender, RoutedEventArgs e)
        {
            ClientsWindow clients = new ClientsWindow();
            clients.Show();
            Close();
        }
        private void ButtonEmployeesClick(object sender, RoutedEventArgs e)
        {
            var emp = new EmployeeWindow();
            emp.Show();
            Close();
        }
        private void ButtonSettingsClick(object sender, RoutedEventArgs e)
        {
            SettingsWindow set = new SettingsWindow();
            set.Show();
            Close();
        }
    }
}
