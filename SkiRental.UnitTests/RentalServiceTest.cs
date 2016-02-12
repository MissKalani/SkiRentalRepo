using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using SkiRental.Models;
using SkiRental.Repositories;
using SkiRental.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiRental.UnitTests
{
    [TestClass]
    public class RentalServiceTest
    {
        [TestMethod]
        public void CreateRentalWillCreateRentalObject()
        {
           
            //Arrange
            var testHelper = new TestHelper();
            var testData = testHelper.CreateEquipmentList();

            IRentalRepository rentalRepository = Substitute.For<IRentalRepository>();
           

            IUnitOfWork uow = Substitute.For<IUnitOfWork>();
            uow.RentalRepository.Returns(rentalRepository);

            RentalService rs = new RentalService(uow);
            
            Rental rental = new Rental();
            rental.CustomerName = "Johan Eriksson";
            rental.CustomerPhoneNumber = "0705556677";
            rental.StartTime = DateTime.Now;
            rental.EquipmentId = testData[0].Id;

            RentalPlan rp = new RentalPlan();
            rp.Id = 1;
            rp.Duration = 8;
            rp.Discount = 0;

            rental.RentalPlanId = rp.Id;

            //Act
            rs.CreateRental(rental);

            //Assert
            rentalRepository.Received().CreateRental(rental);

        }

        [TestMethod]
        public void GetAllRentalsShouldContainTwoRentals()
        {
            //Arrange

            var testHelper = new TestHelper();
            var testData = testHelper.CreateEquipmentList();

            RentalPlan rp = new RentalPlan();
            rp.Id = 1;
            rp.Duration = 8;
            rp.Discount = 0;

            Rental rental = new Rental();
            rental.CustomerName = "Johan Eriksson";
            rental.CustomerPhoneNumber = "0705556677";
            rental.StartTime = DateTime.Now;
            rental.EquipmentId = testData[0].Id;
            rental.RentalPlanId = rp.Id;

            Rental rental2 = new Rental();
            rental2.CustomerName = "Johan Eriksson";
            rental2.CustomerPhoneNumber = "0705556677";
            rental2.StartTime = DateTime.Now;
            rental2.EquipmentId = testData[1].Id;
            rental2.RentalPlanId = rp.Id;

            IRentalRepository rentalRepository = Substitute.For<IRentalRepository>();
            rentalRepository.GetAllRentals().Returns(new List<Rental> { rental, rental2});

            IUnitOfWork uow = Substitute.For<IUnitOfWork>();
            uow.RentalRepository.Returns(rentalRepository);

            RentalService rs = new RentalService(uow);

            //Act
            var rentals = rs.GetAllRentals();

            //Assert
            rentals.Should().HaveCount(2);
        }

        [TestMethod]
        public void CreateRentalWithRentedEquipmentShouldFail()
        {
            //Arrange
            IRentalRepository rentalRepository = Substitute.For< IRentalRepository >();
            rentalRepository.GetRentalByEquipmentId(2).Returns(new Rental());

            IUnitOfWork uow = Substitute.For<IUnitOfWork>();
            uow.RentalRepository.Returns(rentalRepository);

            RentalService rs = new RentalService(uow);

            //Act
            var result = rs.CreateRental(new Rental { EquipmentId = 2 });

            //Assert
            result.Should().Be(CreateRentalResult.EquipmentIsAlreadyRented);
        }

        [TestMethod]
        public void GetRentalByRentalIdReturnsRightRental()
        {
            //Arrange
            IRentalRepository rentalRepository = Substitute.For<IRentalRepository>();
            rentalRepository.GetRentalByRentalId(2).Returns(new Rental {CustomerName = "Lars" });

            IUnitOfWork uow = Substitute.For<IUnitOfWork>();
            uow.RentalRepository.Returns(rentalRepository);

            RentalService rs = new RentalService(uow);

            //Act
            var rental = rs.GetRentalByRentalId(2);

            //Assert
            rental.CustomerName.Should().Be("Lars");
        }       
    }
}
