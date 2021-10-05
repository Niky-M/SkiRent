using SkiRent.Windows.Rent;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace SkiRent
{
    class Services : Window
    {
        public void ButtonEquipmentClick(object sender, RoutedEventArgs e)
        {
            SkiWindow equip = new SkiWindow();
            equip.Show();
            Close();
        }
    }
}
