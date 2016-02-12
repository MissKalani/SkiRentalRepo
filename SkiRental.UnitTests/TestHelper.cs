using SkiRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiRental.UnitTests
{
    public class TestHelper
    {
        public TestHelper()
        {
                
        }

        public List<Equipment> CreateEquipmentList()
        {
            Equipment e1 = new Equipment();
            e1.ProductName = "EqTest1";
            e1.PurchaseDate = DateTime.Now;
            e1.PurchasePrice = 50;
            e1.EquipmentType = new EquipmentType { TypeName = "SkiBoots", PricePerHour = 50 };
            e1.EquipmentState = new EquipmentState { Description = "Ugly" };


            Equipment e2 = new Equipment();
            e2.ProductName = "EqTest2";
            e2.PurchaseDate = DateTime.Now;
            e2.PurchasePrice = 500;
            e2.EquipmentType = new EquipmentType { TypeName = "Skis", PricePerHour = 500 };
            e2.EquipmentState = new EquipmentState { Description = "Damaged" };


            var testData = new List<Equipment>();
            testData.Add(e1);
            testData.Add(e2);

            return testData;
        }
    }
}
