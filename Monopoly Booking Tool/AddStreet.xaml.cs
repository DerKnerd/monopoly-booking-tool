using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Monopoly_Booking_Tool {
    /// <summary>
    /// Interaktionslogik für AddStreet.xaml
    /// </summary>
    public partial class AddStreet : Window {
        public AddStreet(StreetCollection streets) {
            InitializeComponent();
            this.streets = streets;
        }

        public StreetCollection streets = null;
        private void add_Click(object sender, RoutedEventArgs e) {
            Street s = new Street(Convert.ToInt32(tb_normalrent.Text), Convert.ToInt32(tb_rentone.Text),
                                Convert.ToInt32(tb_renttwo.Text), Convert.ToInt32(tb_rentthree.Text),
                                Convert.ToInt32(tb_rentfour.Text), Convert.ToInt32(tb_rentfive.Text), tb_name.Text);
            streets.Add(s);
            this.DialogResult = true;
            this.Close();
        }

        private void cancel_Click(object sender, RoutedEventArgs e) {
            this.DialogResult = false;
            this.Close();
        }
    }
}
