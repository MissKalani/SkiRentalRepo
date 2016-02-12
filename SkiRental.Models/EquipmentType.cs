using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiRental.Models
{
    public class EquipmentType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public double PricePerHour { get; set; }
    }
}
