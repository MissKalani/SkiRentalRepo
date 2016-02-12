using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiRental.Models;
using SkiRental.Repositories;

namespace SkiRental.ServiceLayer
{
    public class EquipmentService : IEquipmentService
    {
        private IUnitOfWork uow;

        public EquipmentService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public List<Equipment> GetAllEquipments()
        {
            return uow.EquipmentRepository.GetAllEquipments();
        }

        public Equipment GetEquipmentById(int id)
        {
            return uow.EquipmentRepository.GetEquipmentById(id);
        }
                

        public List<Equipment> GetEquipmentsByRentalState(bool isRented)
        {
            return uow.EquipmentRepository.GetEquipmentsByRentalState(isRented);
        }
    }
}
