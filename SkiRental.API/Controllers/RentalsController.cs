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
    public class RentalsController : ApiController
    {

        IRentalService rentalService = new RentalService(new UnitOfWork());

        //POST api/rentals
        [ResponseType(typeof(Rental))]
        public IHttpActionResult PostRental(Rental rental)
        {
            if (ModelState.IsValid)
            {
                rental.RentalPlan = null;
                rental.Equipment = null;

                var result = rentalService.CreateRental(rental);

                if(result == CreateRentalResult.Success)
                {
                    return Ok(rental);
                }
                else
                {
                    return Conflict();
                }             
            }
            else
            {
                return BadRequest();
            }    
        }

        //GET api/rentals
        [ResponseType(typeof(List<Rental>))]
        public IHttpActionResult GetAllRentals()
        {
            var rentals = rentalService.GetAllRentals();
            return Ok(rentals);
        }

        //GET api/rentals/id
        [ResponseType(typeof(Rental))]
        public IHttpActionResult GetRentalByRentalId(int id)
        {
            var rental = rentalService.GetRentalByRentalId(id);

            if(rental == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(rental);
            }           
        }

        //DELETE api/rentals/id      
        public IHttpActionResult DeleteRental(int id)
        {
            Rental rental = rentalService.GetRentalByRentalId(id);
            if(rental == null)
            {
                return NotFound();
            }
            else
            {
                rentalService.DeleteRental(rental.Id);
                return Ok();
            }                   
        }
    }
}
