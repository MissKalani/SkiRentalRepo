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
    public class StatesController : ApiController
    {
        IEquipmentStatesService equipmentStatesService = new EquipmentStatesService(new UnitOfWork());

        [ResponseType (typeof(List<EquipmentState>))]
        public IHttpActionResult GetEquipmentStates()
        {
            return Ok(equipmentStatesService.GetEquipmentStates());
        }

        [ResponseType(typeof(EquipmentState))]
        public IHttpActionResult GetEquipmentStateByEquipmentId(int equipmentId)
        {
            return Ok(equipmentStatesService.GetEquipmentStateByEquipmentId(equipmentId));
        }
    }
}
