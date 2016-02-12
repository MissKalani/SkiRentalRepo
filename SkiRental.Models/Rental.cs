using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiRental.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public int EquipmentId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; }
        public DateTime StartTime { get; set; }
        public int RentalPlanId { get; set; }

        public Equipment Equipment { get; set; }
        public RentalPlan RentalPlan { get; set; }
    }
}
