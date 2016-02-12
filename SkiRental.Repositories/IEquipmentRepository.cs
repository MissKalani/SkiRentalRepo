using SkiRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiRental.Repositories
{
    public interface IEquipmentRepository
    {
        List<Equipment> GetAllEquipments();
        Equipment GetEquipmentById(int id);

        List<Equipment> GetEquipmentsByRentalState(bool isRented);
    }
}
