using SkiRent.Models;
using System;
using System.Windows;
using Microsoft.EntityFrameworkCore;

namespace SkiRent.Windows.Rent
{
    public partial class ChangeClientInfo : Window
    {
        public ChangeClientInfo()
        {
            InitializeComponent();
            LoadSelectedClient();
        }
        void LoadSelectedClient()
        {
            tbName.Text = ClientsWindow.SelectedClient.Name;
            tbPhone.Text = Convert.ToString(ClientsWindow.SelectedClient.Phone);
            tbHeight.Text = Convert.ToString(ClientsWindow.SelectedClient.Height);
            tbWeight.Text = Convert.ToString(ClientsWindow.SelectedClient.Weight);
            tbSize.Text = Convert.ToString(ClientsWindow.SelectedClient.Size);
        }
        private void ButtonSaveClick(object sender, RoutedEventArgs e)
        {
            using var context = new SkiRent02Context();
            {
                ClientsWindow.SelectedClient.Name = tbName.Text;
                ClientsWindow.SelectedClient.Phone = Convert.ToInt64(tbPhone.Text);
                ClientsWindow.SelectedClient.Height = Convert.ToInt32(tbHeight.Text);
                ClientsWindow.SelectedClient.Weight = Convert.ToInt32(tbWeight.Text);
                ClientsWindow.SelectedClient.Size = Convert.ToInt32(tbSize.Text);
                ClientsWindow.SelectedClient.Login = tbName.Text;
                ClientsWindow.SelectedClient.Password = tbPhone.Text;
                context.Entry(ClientsWindow.SelectedClient).State = EntityState.Modified;
                context.SaveChanges();
            }
            Close();
        }
    }
}
