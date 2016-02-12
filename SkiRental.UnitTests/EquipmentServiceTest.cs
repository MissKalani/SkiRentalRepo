using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using SkiRental.ServiceLayer;
using SkiRental.Models;
using System.Collections.Generic;
using FluentAssertions;
using SkiRental.Repositories;

namespace SkiRental.UnitTests
{
    [TestClass]
    public class EquipmentServiceTest
    {
        [TestMethod]
        public void WillReturnEquipmentList()
        {
            //Arrange
            var testHelper = new TestHelper();
            var testData = testHelper.CreateEquipmentList();

            IEquipmentRepository eqRepository = Substitute.For<IEquipmentRepository>();
            eqRepository.GetAllEquipments().Returns(testData);

            IUnitOfWork uow = Substitute.For<IUnitOfWork>();
            uow.EquipmentRepository.Returns(eqRepository);

            EquipmentService eService = new EquipmentService(uow);

            //Act
            var equipments = eService.GetAllEquipments();
            //Assert
            equipments.Should().NotBeNull();

        }
        [TestMethod]
        public void WillReturnSecondEquipment()
        {
            //Arrange
            var testHelper = new TestHelper();
            var testData = testHelper.CreateEquipmentList();
            int id = testData[1].Id;

            IEquipmentRepository eqRepository = Substitute.For<IEquipmentRepository>();
            eqRepository.GetEquipmentById(id).Returns(testData[1]);

            IUnitOfWork uow = Substitute.For<IUnitOfWork>();
            uow.EquipmentRepository.Returns(eqRepository);

            EquipmentService eService = new EquipmentService(uow);

            //Act            
            var equipmentTaken = eService.GetEquipmentById(id);

            //Assert
            equipmentTaken.ProductName.Should().Be("EqTest2");

        }  



    }
}
