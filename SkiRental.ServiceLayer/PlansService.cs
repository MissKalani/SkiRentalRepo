using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiRental.Models;
using SkiRental.Repositories;

namespace SkiRental.ServiceLayer
{
    public class PlansService : IPlansService
    {
        private IUnitOfWork uow;

        public PlansService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public RentalPlan GetRentalPlanById(int id)
        {
            return uow.PlansRepository.GetRentalPlanById(id);
        }

        public List<RentalPlan> GetRentalPlans()
        {
            return uow.PlansRepository.GetRentalPlans();
        }

    }
}
