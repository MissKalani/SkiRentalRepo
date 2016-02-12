using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiRental.Models;
using SkiRental.DataAccess;

namespace SkiRental.Repositories
{
    public class TypesRepository : ITypesRepository
    {
        private SkiRentalContext context;

        public TypesRepository(SkiRentalContext context)
        {
            this.context = context;
        }
        public EquipmentType GetEquipmentTypeByEquipmentId(int id)
        {    
            var equipment = context.Equipments.Include(e => e.EquipmentType).Where(e => e.Id == id).SingleOrDefault();
            return equipment == null ? null : equipment.EquipmentType;                     
        }

        public List<EquipmentType> GetEquipmentTypes()
        {
            return context.EquipmentTypes.ToList();
        }
    }
}
