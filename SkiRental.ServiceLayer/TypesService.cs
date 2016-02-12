using SkiRental.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiRental.Models;

namespace SkiRental.ServiceLayer
{

    public class TypesService : ITypesService
    {
        private IUnitOfWork uow;

        public TypesService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public EquipmentType GetEquipmentTypeByEquipmentId(int id)
        {
            return uow.TypesRepository.GetEquipmentTypeByEquipmentId(id);
        }

        public List<EquipmentType> GetEquipmentTypes()
        {
            return uow.TypesRepository.GetEquipmentTypes();
        }
    }
}
