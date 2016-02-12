using SkiRental.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiRental.RentalGUI.ViewModels
{
    public class MainWindowVM
    {
        public ObservableCollection<Equipment> AvailableEquipment { get; set; }
        public ObservableCollection<RentalItem> Rentals { get; set; }
        public Rental SelectedRentalToReturn { get; set; }

        public MainWindowVM()
        {
            AvailableEquipment = new ObservableCollection<Equipment>();
            Rentals = new ObservableCollection<RentalItem>();
        }
    }
}
