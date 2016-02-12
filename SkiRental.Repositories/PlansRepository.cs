using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiRental.DataAccess;
using SkiRental.Models;

namespace SkiRental.Repositories
{
    public class PlansRepository : IPlansRepository
    {
        private SkiRentalContext context;

        public PlansRepository(SkiRentalContext context)
        {
            this.context = context;
        }

        public RentalPlan GetRentalPlanById(int id)
        {
            return context.RentalPlans.Find(id);
        }

        public List<RentalPlan> GetRentalPlans()
        {
            return context.RentalPlans.ToList();
        }
    }
}
