using SkiRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiRental.ServiceLayer
{
    public interface IPlansService
    {
        List<RentalPlan> GetRentalPlans();
        RentalPlan GetRentalPlanById(int id);
    }
}
