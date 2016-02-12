using SkiRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiRental.ServiceLayer
{
    public interface ITypesService
    {
        List<EquipmentType> GetEquipmentTypes();
        EquipmentType GetEquipmentTypeByEquipmentId(int id);

    }
}
