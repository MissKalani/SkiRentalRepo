using SkiRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiRental.Repositories
{
    public interface IPlansRepository
    {
        List<RentalPlan> GetRentalPlans();
        RentalPlan GetRentalPlanById(int id);
    }
}
