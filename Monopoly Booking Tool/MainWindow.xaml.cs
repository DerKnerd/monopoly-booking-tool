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
using Monopoly_Booking_Tool.Pages;

namespace Monopoly_Booking_Tool {
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            this.Language = XmlLanguage.GetLanguage("de-de");
            playermanagement.Content = new PlayerManagement(this);
            streetmanagement.Content = new StreetManagement(this);
        }
        public StreetCollection streets = new StreetCollection();
    }
}
