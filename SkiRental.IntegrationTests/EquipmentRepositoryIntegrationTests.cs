using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SkiRental.DataAccess;
using SkiRental.Repositories;
using SkiRental.Models;
using FluentAssertions;

namespace SkiRental.IntegrationTests
{
    [TestClass]
    public class EquipmentRepositoryIntegrationTests : RollBackTestClass
    {
        [TestMethod]
        public void GetAllEquipmentsReturnsNotNull()
        {
            using (var context = new SkiRentalContext())
            {
                var uow = new UnitOfWork(context);

                Equipment e1 = new Equipment();
                e1.ProductName = "EQtest1";
                e1.EquipmentTypeId = 1;
                e1.EquipmentStateId = 1;
                e1.PurchaseDate = DateTime.Now;
                e1.PurchasePrice = 500;

                context.Equipments.Add(e1);
                uow.Save();


            }
            using (var context = new SkiRentalContext())
            {
                var uow = new UnitOfWork(context);
                uow.EquipmentRepository.GetAllEquipments().Should().NotBeNull();
            }

        }

        [TestMethod]
        public void GetEquipmentByIdReturnsAnEquipment()
        {
            int id = 0;

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
                id = e2.Id;
            }
            using (var context = new SkiRentalContext())
            {
                var uow = new UnitOfWork(context);
                uow.EquipmentRepository.GetEquipmentById(id).Should().NotBeNull();
                uow.EquipmentRepository.GetEquipmentById(id).ProductName.Should().Be("EQtest2");
                uow.EquipmentRepository.GetEquipmentById(0).Should().BeNull();
            }
        }


        [TestMethod]
        public void GetEquipmentsByRentalStateReturnsEquipmentsWithCorrectRentalState()
        {
            int availableId;
            int rentedId;
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


                RentalPlan rp1 = new RentalPlan();
                rp1.Duration = 8;
                rp1.Discount = 0.25;

                context.RentalPlans.Add(rp1);

                Rental rental = new Rental();
                rental.CustomerName = "Johan Eriksson";
                rental.CustomerPhoneNumber = "0705556677";
                rental.StartTime = DateTime.Now;
                rental.Equipment = e1;
                rental.RentalPlan = rp1;                

                uow.RentalRepository.CreateRental(rental);      
                uow.Save();

                availableId = e2.Id;
                rentedId = e1.Id;   
            }
            using (var context = new SkiRentalContext())
            {
                var uow = new UnitOfWork(context);

                var availableEq = uow.EquipmentRepository.GetEquipmentsByRentalState(false);
                var rentedEq = uow.EquipmentRepository.GetEquipmentsByRentalState(true);

                availableEq.Should().HaveCount(1);               
                rentedEq.Should().HaveCount(1);

                availableEq[0].Id.Should().Be(availableId);
                rentedEq[0].Id.Should().Be(rentedId);
            }
        }

    }
}
