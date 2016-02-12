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
    public class TypesController : ApiController
    {
        ITypesService typesService = new TypesService(new UnitOfWork());

        //GET api/types
        [ResponseType (typeof (List<EquipmentType>))]
        public IHttpActionResult GetEquipmentTypes()
        {
            return Ok(typesService.GetEquipmentTypes());
        }

        //GET api/types/id
        [ResponseType(typeof(EquipmentType))]
        public IHttpActionResult GetEquipmentTypeByEquipmentId(int equipmentId)
        {         
            return Ok(typesService.GetEquipmentTypeByEquipmentId(equipmentId));
        }
    }
}
