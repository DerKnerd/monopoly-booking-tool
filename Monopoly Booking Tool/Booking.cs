using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Monopoly_Booking_Tool {
    [Serializable]
    public class PlayerCollection : ObservableCollection<Player> {
    }
    [Serializable]
    public class BookingCollection : ObservableCollection<Booking> {
    }
    [Serializable]
    public class StreetCollection : ObservableCollection<Street> {
        public void ClearAppartments() {
            foreach (var item in this) {
                item.AppartmentCount = 0;
            }
        }
    }
    [Serializable]
    public class Player {
        public Player() {
            Book = new BookingCollection();
        }
        private string name;
        private BookingCollection book;

        public BookingCollection Book {
            get { return book; }
            set { book = value; }
        }

        public string Name {
            get { return name; }
            set { name = value; }
        }
        public override string ToString() {
            return Name;
        }
    }
    [Serializable]
    public class Booking {
        public Booking() {
        }
        public Booking(int current, int add, string subject = "") {
            this.Current = current;
            this.Additional = add;
            this.Subject = subject;
        }
        public int Current { get; set; }
        public int Additional { get; set; }
        public string Subject { get; set; }
        public int New { get { return Current + Additional; } }
        public bool Positiv { get { return New > Current; } }
    }
    [Serializable]
    public class Street {
        public Street() {
        }
        public Street(int RentNormal, int RentOneApp, int RentTwoApp, int RentThreeApp, int RentFourApp, int RentHotel, string Name) {
            this.Name = Name;
            this.RentNormal = RentNormal;
            this.RentOneApp = RentOneApp;
            this.RentTwoApp = RentTwoApp;
            this.RentThreeApp = RentThreeApp;
            this.RentFourApp = RentFourApp;
            this.RentHotel = RentHotel;
        }
        public string Name { get; set; }
        public byte AppartmentCount { get; set; }
        public int RentNormal { get; set; }
        public int RentOneApp { get; set; }
        public int RentTwoApp { get; set; }
        public int RentThreeApp { get; set; }
        public int RentFourApp { get; set; }
        public int RentHotel { get; set; }
        public int CurrentRent {
            get {
                int res = 0;
                switch (AppartmentCount) {
                    case 1: res = RentOneApp;
                        break;
                    case 2: res = RentTwoApp;
                        break;
                    case 3: res = RentThreeApp;
                        break;
                    case 4: res = RentFourApp;
                        break;
                    case 5: res = RentHotel;
                        break;
                    default: res = RentNormal;
                        break;
                }
                return res;
            }
        }
        public void AddAppartment() {
            AppartmentCount++;
        }
        public void RemoveAppartment() {
            AppartmentCount--;
        }
        public override string ToString() {
            return Name;
        }
    }
}
