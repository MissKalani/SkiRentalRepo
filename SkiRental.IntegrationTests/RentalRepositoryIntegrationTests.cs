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
    public class RentalRepositoryIntegrationTests : RollBackTestClass
    {
        [TestMethod]
        public void CreateRentalShouldStoreRental()
        {
            int eqid;
            int rpid;

            using (var context = new SkiRentalContext())
            {
                var uow = new UnitOfWork(context);

                Equipment e1 = new Equipment();
                e1.ProductName = "EQtest1";
                e1.EquipmentTypeId = 1;
                e1.EquipmentStateId = 1;
                e1.PurchaseDate = DateTime.Now;
                e1.PurchasePrice = 500;

                RentalPlan rp1 = new RentalPlan();
                rp1.Duration = 8;
                rp1.Discount = 0.25;

                context.Equipments.Add(e1);
                context.RentalPlans.Add(rp1);
                uow.Save();

                eqid = e1.Id;
                rpid = rp1.Id;

            }
            using (var context = new SkiRentalContext())
            {
                var uow = new UnitOfWork(context);

                Rental rental = new Rental();
                rental.CustomerName = "Johan Eriksson";
                rental.CustomerPhoneNumber = "0705556677";
                rental.StartTime = DateTime.Now;
                rental.EquipmentId = eqid;
                rental.RentalPlanId = rpid;

                uow.RentalRepository.CreateRental(rental);
                uow.Save();
            }

            using (var context = new SkiRentalContext())
            {
                context.Rentals.Should().NotBeNullOrEmpty();
                context.Rentals.Where(r => r.CustomerName == "Johan Eriksson").Should().HaveCount(1);
            }

        }
        [TestMethod]
        public void GetAllRentalsShouldNotBeEmpty()
        {     

            using (var context = new SkiRentalContext())
            {
                var uow = new UnitOfWork(context);
                var eqList = CreateEquipmentList();

                RentalPlan rp1 = new RentalPlan();
                rp1.Duration = 8;
                rp1.Discount = 0.25;

                context.RentalPlans.Add(rp1);

                Rental rental = new Rental();
                rental.CustomerName = "Johan Eriksson";
                rental.CustomerPhoneNumber = "0705556677";
                rental.StartTime = DateTime.Now;
                rental.EquipmentId = eqList[0].Id;
                rental.RentalPlanId = rp1.Id;

                Rental rental2 = new Rental();
                rental2.CustomerName = "Anna Nilsson";
                rental2.CustomerPhoneNumber = "0738887766";
                rental2.StartTime = DateTime.Now;
                rental2.EquipmentId = eqList[1].Id;
                rental2.RentalPlanId = rp1.Id;

                uow.RentalRepository.CreateRental(rental);
                uow.RentalRepository.CreateRental(rental2);
                uow.Save();
            }

            using (var context = new SkiRentalContext())
            {
                var uow = new UnitOfWork(context);

                var rentals = uow.RentalRepository.GetAllRentals();

                rentals.Should().NotBeEmpty();
            }
        }

        [TestMethod]

        public void GetRentalByEquipmentIDReturnsRightRental()
        {
            int eqid;

            using (var context = new SkiRentalContext())
            {
                var uow = new UnitOfWork(context);
                var eqList = CreateEquipmentList();

                RentalPlan rp1 = new RentalPlan();
                rp1.Duration = 8;
                rp1.Discount = 0.25;

                context.RentalPlans.Add(rp1);

                eqid = eqList[1].Id;

                Rental rental = new Rental();
                rental.CustomerName = "Johan Eriksson";
                rental.CustomerPhoneNumber = "0705556677";
                rental.StartTime = DateTime.Now;
                rental.EquipmentId = eqList[0].Id;
                rental.RentalPlanId = rp1.Id;          

                Rental rental2 = new Rental();
                rental2.CustomerName = "Anna Nilsson";
                rental2.CustomerPhoneNumber = "0738887766";
                rental2.StartTime = DateTime.Now;
                rental2.EquipmentId = eqid;
                rental2.RentalPlanId = rp1.Id;
               

                uow.RentalRepository.CreateRental(rental);
                uow.RentalRepository.CreateRental(rental2);
                uow.Save();

            }
            using (var context = new SkiRentalContext())
            {
                var uow = new UnitOfWork(context);
                var rental = uow.RentalRepository.GetRentalByEquipmentId(eqid);

                rental.CustomerName.Should().Be("Anna Nilsson");
            }    

        }

        [TestMethod]
        public void GetRentalByRentalIdReturnsRightRental()
        {
            int rentalId;

            using (var context = new SkiRentalContext())
            {
                var uow = new UnitOfWork(context);
                var eqList = CreateEquipmentList();

                RentalPlan rp1 = new RentalPlan();
                rp1.Duration = 8;
                rp1.Discount = 0.25;

                context.RentalPlans.Add(rp1);

                Rental rental = new Rental();
                rental.CustomerName = "Johan Eriksson";
                rental.CustomerPhoneNumber = "0705556677";
                rental.StartTime = DateTime.Now;
                rental.EquipmentId = eqList[0].Id;
                rental.RentalPlanId = rp1.Id;                

                Rental rental2 = new Rental();
                rental2.CustomerName = "Anna Nilsson";
                rental2.CustomerPhoneNumber = "0738887766";
                rental2.StartTime = DateTime.Now;
                rental2.EquipmentId = eqList[1].Id;
                rental2.RentalPlanId = rp1.Id;

                uow.RentalRepository.CreateRental(rental);
                uow.RentalRepository.CreateRental(rental2);
                uow.Save();

                rentalId = rental.Id;
            }
            using (var context = new SkiRentalContext())
            {
                var uow = new UnitOfWork(context);
                var rental = uow.RentalRepository.GetRentalByRentalId(rentalId);

                rental.CustomerName.Should().Be("Johan Eriksson");
            }
        }


        private static List<Equipment> CreateEquipmentList()
        {
            using (var context = new SkiRentalContext())
            {
                var uow = new UnitOfWork(context);

                Equipment e1 = new Equipment();
                e1.ProductName = "EqTest1";
                e1.PurchaseDate = DateTime.Now;
                e1.PurchasePrice = 50;
                e1.EquipmentTypeId = 1;
                e1.EquipmentStateId = 2;


                Equipment e2 = new Equipment();
                e2.ProductName = "EqTest2";
                e2.PurchaseDate = DateTime.Now;
                e2.PurchasePrice = 500;
                e2.EquipmentTypeId = 2;
                e2.EquipmentStateId = 1;

                context.Equipments.Add(e1);
                context.Equipments.Add(e2);
                uow.Save();

                return context.Equipments.ToList();
            }
        }
        



    }
}
