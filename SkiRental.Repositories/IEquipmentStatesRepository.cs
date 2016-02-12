using SkiRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiRental.Repositories
{
    public interface IEquipmentStatesRepository
    {
        List<EquipmentState> GetEquipmentStates();
        EquipmentState GetEquipmentStateByEquipmentId(int id);
    }
}
