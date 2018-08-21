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
    /// Interaktionslogik für Transaction.xaml
    /// </summary>
    public partial class Transaction : Window {
        public Transaction(PlayerCollection players, StreetCollection streets) {
            InitializeComponent();
            this.players = players;
            receiver.ItemsSource = players;
            payer.ItemsSource = players;
            this.streets.ItemsSource = streets;
        }

        public PlayerCollection players = new PlayerCollection();

        private void calc_Click(object sender, RoutedEventArgs e) {
            bool ret = false;
            int value = 0;
            ret = receiver.SelectedItem as Player != null && int.TryParse(amount.Text, out value);
            if (ret == false) {
                MessageBox.Show("Bitte einen Empfänger und einen gültigen Betrag angeben", "Fehler");
                return;
            }
            Player rec = receiver.SelectedItem as Player;
            if (rec.Book.Count > 0)
                rec.Book.Insert(0, new Booking(rec.Book[0].New, value, subject.Text));
            else
                rec.Book.Insert(0, new Booking(0, value, subject.Text));
            if (payer.SelectedItem as Player != null) {
                Player pay = payer.SelectedItem as Player;
                if (pay.Book.Count > 0)
                    pay.Book.Insert(0, new Booking(pay.Book[0].New, value * -1, subject.Text));
                else
                    pay.Book.Insert(0, new Booking(0, value * -1, subject.Text));
            }
            this.DialogResult = true;
            this.Close();
        }

        private void cancel_Click(object sender, RoutedEventArgs e) {
            this.DialogResult = false;
            this.Close();
        }

        private void streets_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            Street street = streets.SelectedItem as Street;
            Player payer = this.payer.SelectedItem as Player;
            Player receiver = this.receiver.SelectedItem as Player;
            amount.Text = street.CurrentRent.ToString();
            subject.Text = "Miete von " + payer.Name + " an " + receiver.Name + " für " + street.Name;
        }
    }
}
