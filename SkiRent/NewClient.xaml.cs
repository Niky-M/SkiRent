using System;

using System.Windows;
using SkiRent.Models;

namespace SkiRent
{
    public partial class NewClient : Window
    {

        public NewClient()
        {
            InitializeComponent();
        }

        private void addClientButton(object sender, RoutedEventArgs e)
        {
            //if (height.Text == String.Empty)
            //    MessageBox.Show("height is empty!");
            // проверка введенных данных
            int result;
            Int64 phonResult;
            if (String.IsNullOrEmpty(phone.Text) || !Int64.TryParse(phone.Text, out phonResult) || Convert.ToInt64(phone.Text) < 10000000000 || Convert.ToInt64(phone.Text) >= 100000000000)
            {
                MessageBox.Show("Phone has to be an integer number consisting of 11 figures!");
                return;
            }
            if (String.IsNullOrEmpty(height.Text) || !Int32.TryParse(height.Text, out result) || Convert.ToInt32(height.Text) < 80 || Convert.ToInt32(height.Text) > 250)
            {
                MessageBox.Show("Height has to be an integer number from 80 to 250!");
                return;
            }

            if (String.IsNullOrEmpty(weight.Text) || !Int32.TryParse(weight.Text, out result) || Convert.ToInt32(weight.Text) < 20 || Convert.ToInt32(weight.Text) > 150)
            {
                MessageBox.Show("Weight has to be an integer number from 20 to 150!");
                return;
            }
            if (String.IsNullOrEmpty(size.Text) || !Int32.TryParse(size.Text, out result) || Convert.ToInt32(size.Text) < 24 || Convert.ToInt32(size.Text) > 47)
            {
                MessageBox.Show("size has to be an integer number!");
                return;
            }

            //MessageBox.Show(result.ToString());
            OrderWindow orderWindow = new OrderWindow();
            orderWindow.Show();
            orderWindow.heightTb.Text = height.Text;
            orderWindow.weightTb.Text = weight.Text;
            orderWindow.sizeTb.Text = size.Text;

            var db = new SkiRent02Context();
            var client = new Client()
            {
                Name = name.Text,
                Phone = Convert.ToInt64(phone.Text),
                Height = Convert.ToInt32(height.Text),
                Weight = Convert.ToInt32(weight.Text),
                Size = Convert.ToInt32(size.Text),
                Login = name.Text,
                Password = Convert.ToString(phone.Text)
            };
            db.Clients.Add(client);
            db.SaveChanges();

            MainWindow mainWindow = new MainWindow();
            mainWindow.Close();
            Close();



        }
    }
}
