using SkiRental.Models;
using SkiRental.Repositories;
using SkiRental.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace SkiRental.API.Controllers
{
    public class PlansController : ApiController
    {

        IPlansService planService = new PlansService(new UnitOfWork()); 

        //GET api/plans
        [ResponseType (typeof(List<RentalPlan>))]
        public IHttpActionResult GetRentalPlans()
        {
            var rentalPlans =  planService.GetRentalPlans();
            return Ok(rentalPlans);
        }

        //GET api/plans/id
        [ResponseType (typeof(RentalPlan))]
        public IHttpActionResult GetRentalPlanById(int id)
        {
            var rentalPlan = planService.GetRentalPlanById(id);
            return Ok(rentalPlan);
        }
    }
}
