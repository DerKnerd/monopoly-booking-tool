using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Monopoly_Booking_Tool {
    public static class Commands {
        static Commands() {
            addAppartment = new RoutedUICommand("Hinzufügen", "Change", typeof(Commands));
            removeAppartment = new RoutedUICommand("Löschen", "Remove", typeof(Commands));
        }

        private static RoutedUICommand addAppartment;
        private static RoutedUICommand removeAppartment;

        public static RoutedUICommand AddAppartment {
            get { return addAppartment; }
        }
        public static RoutedUICommand RemoveAppartment {
            get { return removeAppartment; }
        }
    }
}
