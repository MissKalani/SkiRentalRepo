using SkiRental.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiRental.ServiceLayer
{
    public class PricesService : IPricesService
    {
        private IUnitOfWork uow;
        public PricesService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public double GetPrice(int equipmentId, int planId)
        {
            var equipmentType = uow.TypesRepository.GetEquipmentTypeByEquipmentId(equipmentId);
            var plan = uow.PlansRepository.GetRentalPlanById(planId);

            var price = (equipmentType.PricePerHour * plan.Duration) * (1 - plan.Discount);
            return price;
        }

    }
}
