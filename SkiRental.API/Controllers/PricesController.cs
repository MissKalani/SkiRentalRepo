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
    public class PricesController : ApiController
    {
        IPricesService pricesService = new PricesService(new UnitOfWork());

        //GET api/prices?equipmentId=id&planId=id
        [ResponseType (typeof(double))]
        public IHttpActionResult GetPrice(int equipmentId, int planId)
        {   
            var price = pricesService.GetPrice(equipmentId, planId);           
            return Ok(price);
        }

    }
}
