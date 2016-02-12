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
     public class PricesServiceTest
    {
       [TestMethod]
       public void GetPriceReturnsRightPrice()
        {
            //Arrange
            RentalPlan rPlan = new RentalPlan { Id=1, Discount = 0.25, Duration = 8 };
            EquipmentType eType = new EquipmentType { Id=1, TypeName = "SkiBoots", PricePerHour = 50 };

            ITypesRepository typesRepository = Substitute.For<ITypesRepository>();
            typesRepository.GetEquipmentTypeByEquipmentId(1).Returns(eType);

            IPlansRepository plansRepository = Substitute.For<IPlansRepository>();
            plansRepository.GetRentalPlanById(1).Returns(rPlan);

            IUnitOfWork uow = Substitute.For<IUnitOfWork>();
            uow.PlansRepository.Returns(plansRepository);
            uow.TypesRepository.Returns(typesRepository);

            PricesService pricesService = new PricesService(uow);

            //Act
            var price = pricesService.GetPrice(eType.Id, rPlan.Id);

            //Assert
            price.Should().Be(300);

        }
    }
}
