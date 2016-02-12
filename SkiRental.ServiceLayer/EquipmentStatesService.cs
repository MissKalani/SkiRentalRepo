using SkiRental.Models;
using SkiRental.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiRental.ServiceLayer
{
    public class EquipmentStatesService : IEquipmentStatesService
    {
        private IUnitOfWork uow;
        public EquipmentStatesService(UnitOfWork uow)
        {
            this.uow = uow;
        }

        public EquipmentState GetEquipmentStateByEquipmentId(int id)
        {
            return uow.EquipmentStatesRepository.GetEquipmentStateByEquipmentId(id);
        }

        public List<EquipmentState> GetEquipmentStates()
        {
            return uow.EquipmentStatesRepository.GetEquipmentStates();
        }
    }
}
