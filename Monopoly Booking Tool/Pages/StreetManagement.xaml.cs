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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Markup;

namespace Monopoly_Booking_Tool.Pages {
    /// <summary>
    /// Interaktionslogik für StreetManagement.xaml
    /// </summary>
    public partial class StreetManagement : Page {
        public StreetManagement(MainWindow owner) {
            InitializeComponent();
            this.Language = XmlLanguage.GetLanguage("de-de");
            this.CommandBindings.Add(new CommandBinding(Commands.AddAppartment, addAppartment_Executed, addAppartment_CanExecute));
            this.CommandBindings.Add(new CommandBinding(Commands.RemoveAppartment, removeAppartment_Executed, removeAppartment_CanExecute));
            this.Owner = owner;
        }

        MainWindow Owner = null;
        bool saved = false;
        StreetCollection streets = new StreetCollection();
        string path = "";
        private void addAppartment_Executed(object sender, ExecutedRoutedEventArgs e) {
            Street s = (street.SelectedItem as Street);
            streets[streets.IndexOf((street.SelectedItem as Street))].AddAppartment();
            street.ItemsSource = null;
            street.ItemsSource = streets;
            street.SelectedItem = s;
            Owner.streets = streets;
        }
        private void addAppartment_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            if (street.SelectedItem as Street != null)
                e.CanExecute = true;
        }
        private void removeAppartment_Executed(object sender, ExecutedRoutedEventArgs e) {
            Street s = (street.SelectedItem as Street);
            streets[streets.IndexOf((street.SelectedItem as Street))].RemoveAppartment();
            street.ItemsSource = null;
            street.ItemsSource = streets;
            street.SelectedItem = s;
            Owner.streets = streets;
        }
        private void removeAppartment_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            if (street.SelectedItem as Street != null)
                e.CanExecute = true;
        }
        private void save_Click(object sender, RoutedEventArgs e) {
            if (saved == false) {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "*.xml|*.xml";
                if (sfd.ShowDialog() == true) {
                    FileStream fs = new FileStream(sfd.FileName, FileMode.OpenOrCreate);
                    XmlSerializer xs = new XmlSerializer(streets.GetType());
                    xs.Serialize(fs, streets);
                    fs.Close();
                    path = sfd.FileName;
                    saved = true;
                }
            } else {
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                XmlSerializer xs = new XmlSerializer(streets.GetType());
                xs.Serialize(fs, streets);
                fs.Close();
            }
        }

        private void open_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.xml|*.xml";
            if (ofd.ShowDialog() == true) {
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open);
                XmlSerializer xs = new XmlSerializer(streets.GetType());
                this.streets = (StreetCollection)xs.Deserialize(fs);
                fs.Close();
                path = ofd.FileName;
                saved = true;
                street.ItemsSource = streets;
                Owner.streets = streets;
            }
        }

        private void addStreet_Click(object sender, RoutedEventArgs e) {
            AddStreet addStreet = new AddStreet(streets);
            addStreet.Owner = this.Owner;
            if (addStreet.ShowDialog() == true) {
                streets = addStreet.streets;
                Owner.streets = streets;
            }
        }

        private void remove_Click(object sender, RoutedEventArgs e) {
            Street s = (street.SelectedItem as Street);
            streets.ClearAppartments();
            street.ItemsSource = null;
            street.ItemsSource = streets;
            street.SelectedItem = s;
            Owner.streets = streets;
        }
    }
}
