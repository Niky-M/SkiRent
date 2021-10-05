using SkiRent.Windows.Rent;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SkiRent.Windows.Training
{
    /// <summary>
    /// Логика взаимодействия для Training.xaml
    /// </summary>
    public partial class TrainingWindow : Window
    {
        public TrainingWindow()
        {
            InitializeComponent();
        }
        //-----------------------------------------------------------------
        // верхнее меню
        private void ButtonRentClick(object sender, RoutedEventArgs e)
        {
            var rent = new RentWindow();
            rent.Show();
            Close();
        }
        private void ButtonServiceClick(object sender, RoutedEventArgs e)
        {
            var serv = new ServiceWindow();
            serv.Show();
            Close();
        }
        private void ButtonProfitClick(object sender, RoutedEventArgs e)
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
        //-------------------------------------------------------------------
        // Нижнее меню
        private void ButtonGroupClick(object sender, RoutedEventArgs e)
        {
            var group = new GroupWindow();
            group.Show();
            Close();
        }

        private void ConfirmName(object sender, RoutedEventArgs e)
        {

        }
    }
}
