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
    public class EquipmentsController : ApiController
    {
        IEquipmentService equipmentService = new EquipmentService(new UnitOfWork());

        //GET api/equipments
        [ResponseType(typeof(List<Equipment>))]
        public IHttpActionResult GetAllEquipments()
        {
            var equipmentList = equipmentService.GetAllEquipments();
            return Ok(equipmentList);
        }

        //GET api/equipments/id
        [ResponseType(typeof(Equipment))]
        public IHttpActionResult GetEquipmentById(int id)
        {
            var equipment = equipmentService.GetEquipmentById(id);
            return Ok(equipment);
        }
        
        //Get api/equipments?rented=boolean        
        [ResponseType(typeof(List<Equipment>))]
        public IHttpActionResult GetEquipmentsByRentalState(bool rented)
        {
            var equipmentList = equipmentService.GetEquipmentsByRentalState(rented);
            return Ok(equipmentList);
        }
    

    }
}
