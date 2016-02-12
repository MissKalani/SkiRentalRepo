using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiRental.Models
{
    public class RentalPlan
    {
        public int Id { get; set; }
        public int Duration { get; set; }
        public double Discount { get; set; }
    }
}
