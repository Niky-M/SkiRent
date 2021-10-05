using SkiRent.Models;
using SkiRent.Windows.Rent;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace SkiRent
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Autorization_Click(object sender, RoutedEventArgs e)
        {
            if (name.Text == null || name.Text == "") //проверка на пустое имя
                MessageBox.Show("Укажите имя !");
            else
            { //проверка на наличие имени в базе данных
                SqlConnection sqlcon = new SqlConnection(@"data source=(localdb)\MSSQLLocalDB; Initial Catalog = SkiRent02; Integrated Security=True;");
                //DbSkiRent db = new DbSkiRent();
                string query = $"Select Name, Password as 'EqualWithSpace' from Stuff where Name = N'{name.Text}' and Password = '{password.Password}'";

                SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                
                if (dtbl.Rows.Count == 1)
                {
                    var rent = new RentWindow();
                    rent.ChosenStuffName.Text += name.Text;
                    //rent.ChosenStuffPosition.Text += StuffsPosition;
                    rent.Show();
                    Close();
                }
                else
                    MessageBox.Show("Введено неверное имя или пароль");
            }
        }

        private void BlurEffect_DpiChanged(object sender, DpiChangedEventArgs e)
        {

        }
    }
}