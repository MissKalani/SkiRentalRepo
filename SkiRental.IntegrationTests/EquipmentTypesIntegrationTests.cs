using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SkiRental.DataAccess;
using SkiRental.Models;
using SkiRental.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiRental.IntegrationTests
{
    [TestClass]
    public class EquipmentTypesIntegrationTests
    {
        [TestMethod]
        public void GetEquipmentTypeByEquipmentIdReturnsRightEquipmentType()
        {
            int eqId;
            using (var context = new SkiRentalContext())
            {
                var uow = new UnitOfWork(context);

                Equipment e1 = new Equipment();
                e1.ProductName = "EQtest1";
                e1.EquipmentTypeId = 1;
                e1.EquipmentStateId = 1;
                e1.PurchaseDate = DateTime.Now;
                e1.PurchasePrice = 500;

                Equipment e2 = new Equipment();
                e2.ProductName = "EQtest2";
                e2.EquipmentTypeId = 2;
                e2.EquipmentStateId = 2;
                e2.PurchaseDate = DateTime.Now;
                e2.PurchasePrice = 600;

                context.Equipments.Add(e1);
                context.Equipments.Add(e2);
                uow.Save();

                eqId = e2.Id;
            }
            using (var context = new SkiRentalContext())
            {
                var uow = new UnitOfWork(context);
                var equipmentType = uow.TypesRepository.GetEquipmentTypeByEquipmentId(eqId);

                equipmentType.TypeName.Should().Be("Ski Boots");                
            }
        }

    }
}
