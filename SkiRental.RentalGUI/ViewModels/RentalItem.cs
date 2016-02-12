using SkiRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiRental.RentalGUI.ViewModels
{
    public class RentalItem
    {
        public Rental Rental { get; set; }
        public DateTime DueTime { get; set; }
    }
}
