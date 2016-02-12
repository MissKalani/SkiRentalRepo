using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiRental.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int EquipmentTypeId { get; set; }
        public int EquipmentStateId { get; set; }
        public DateTime  PurchaseDate { get; set; }
        public double  PurchasePrice { get; set; }
        public EquipmentType EquipmentType { get; set; }
        public EquipmentState EquipmentState { get; set; }

    }
}
