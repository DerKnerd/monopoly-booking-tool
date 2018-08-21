using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Monopoly_Booking_Tool {
    public class Converter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            string res = "";
            bool val = System.Convert.ToBoolean(value);
            res = "-";
            if (val == true)
                res = "+";
            return res;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            return value;
        }
    }
    public class StringVisbilityConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            Visibility res = Visibility.Collapsed;
            if (value as ComboBoxItem != null)
                if ((value as ComboBoxItem).Content.ToString().ToLower().Equals("miete"))
                    res = Visibility.Visible;
            return res;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            return value;
        }
    }
}
