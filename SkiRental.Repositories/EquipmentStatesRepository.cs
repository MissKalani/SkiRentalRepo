using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using SkiRental.DataAccess;
using SkiRental.Models;

namespace SkiRental.Repositories
{
    public class EquipmentStatesRepository : IEquipmentStatesRepository
    {
        private SkiRentalContext context;

        public EquipmentStatesRepository(SkiRentalContext context)
        {
            this.context = context;
        }

        public EquipmentState GetEquipmentStateByEquipmentId(int id)
        {
            var equipment = context.Equipments.Include(e => e.EquipmentState).Where(e => e.Id == id).SingleOrDefault();
            return equipment == null ? null : equipment.EquipmentState; 
        }

        public List<EquipmentState> GetEquipmentStates()
        {
            return context.EquipmentStates.ToList();
        }
    }
}
