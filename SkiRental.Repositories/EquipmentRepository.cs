using SkiRental.DataAccess;
using SkiRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiRental.Repositories
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private SkiRentalContext context;
        public EquipmentRepository(SkiRentalContext context)
        {
            this.context = context; 
        }   

        public List<Equipment> GetAllEquipments()
        {
            return context.Equipments.ToList();
        }

        public Equipment GetEquipmentById(int id)
        {
            Equipment equipment = context.Equipments.Find(id);
            return equipment;
        }

        public List<Equipment> GetEquipmentsByRentalState(bool isRented)
        {
            if (isRented)
            {
                var sql = from e in context.Equipments
                          join r in context.Rentals on e.Id equals r.EquipmentId
                          select e;
                return sql.ToList();
            } else
            {         
                return context.Equipments.Where(e => !context.Rentals.Any(r => e.Id == r.EquipmentId)).ToList();
            }      
                      
        }
    }
}
