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
    /// Interaktionslogik für NewPlayer.xaml
    /// </summary>
    public partial class NewPlayer : Window {
        public NewPlayer() {
            InitializeComponent();
        }

        public Player player = null;
        private void button1_Click(object sender, RoutedEventArgs e) {
            player = new Player();
            player.Name = name.Text;
            this.Close();
        }

        private void cancel_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}
