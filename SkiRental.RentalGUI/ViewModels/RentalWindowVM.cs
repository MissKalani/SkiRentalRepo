using SkiRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace SkiRental.RentalGUI.ViewModels
{
    public class RentalWindowVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Equipment _equipment;
        private RentalPlan _selectedRentalPlan;
        private string _customerName;
        private string _customerPhoneNumber;
        private double _calculatedPrice;

        public ObservableCollection<RentalPlanItem> RentalPlanItems { get; set; }

        public RentalWindowVM()
        {
            RentalPlanItems = new ObservableCollection<RentalPlanItem>();
            CustomerName = "";
            CustomerPhoneNumber = "";
        }

        public Equipment Equipment
        {
            get
            {
                return _equipment;
            }

            set
            {
                _equipment = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Equipment"));
            }
        }

        public RentalPlan SelectedRentalPlan
        {
            get
            {
                return _selectedRentalPlan;
            }

            set
            {
                _selectedRentalPlan = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("SelectedRentalPlan"));
            }
        }

        public string CustomerName
        {
            get
            {
                return _customerName;
            }

            set
            {
                _customerName = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("CustomerName"));
            }
        }

        public string CustomerPhoneNumber
        {
            get
            {
                return _customerPhoneNumber;
            }

            set
            {
                _customerPhoneNumber = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("CustomerPhoneNumber"));
            }
        }

        public double CalculatedPrice
        {
            get
            {
                return _calculatedPrice;
            }

            set
            {
                _calculatedPrice = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("CalculatedPrice"));
            }
        }
    }
}
