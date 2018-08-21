using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using Microsoft.Win32;

namespace Monopoly_Booking_Tool.Pages {
    /// <summary>
    /// Interaktionslogik für PlayerManagement.xaml
    /// </summary>
    public partial class PlayerManagement : Page {
        public PlayerManagement(MainWindow owner) {
            InitializeComponent();
            player.ItemsSource = players;
            this.Language = XmlLanguage.GetLanguage("de-de");
            this.Owner = owner;
        }

        MainWindow Owner = null;
        PlayerCollection players = new PlayerCollection();
        bool saved = false;
        string path = "";

        private void addPlayer_Click(object sender, RoutedEventArgs e) {
            NewPlayer ply = new NewPlayer();
            ply.Owner = this.Owner;
            ply.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            ply.ShowDialog();
            this.players.Add(ply.player);
            this.player.SelectedItem = ply.player;
        }

        private void save_Click(object sender, RoutedEventArgs e) {
            if (saved == false) {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "*.xml|*.xml";
                if (sfd.ShowDialog() == true) {
                    FileStream fs = new FileStream(sfd.FileName, FileMode.OpenOrCreate);
                    XmlSerializer xs = new XmlSerializer(players.GetType());
                    xs.Serialize(fs, players);
                    fs.Close();
                    path = sfd.FileName;
                    saved = true;
                }
            } else {
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                XmlSerializer xs = new XmlSerializer(players.GetType());
                xs.Serialize(fs, players);
                fs.Close();
            }
        }

        private void open_Click(object sender, RoutedEventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.xml|*.xml";
            if (ofd.ShowDialog() == true) {
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open);
                XmlSerializer xs = new XmlSerializer(players.GetType());
                this.players = (PlayerCollection)xs.Deserialize(fs);
                player.ItemsSource = players;
                fs.Close();
                path = ofd.FileName;
                saved = true;
            }
        }

        private void trans_Click(object sender, RoutedEventArgs e) {
            Transaction trans = new Transaction(players, Owner.streets);
            trans.Owner = this.Owner;
            if (trans.ShowDialog() == true) {
                players = trans.players;
                //refresh();
            }
        }

        private void player_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            //refresh();
        }

        private void refresh() {
            if ((player.SelectedItem as Player) != null)
                konto.Content = (player.SelectedItem as Player).Book[0].New;
        }
    }
}
