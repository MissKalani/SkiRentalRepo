using SkiRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiRental.Repositories
{
    public interface IRentalRepository
    {
        void CreateRental(Rental rental);
        List<Rental> GetAllRentals();
        Rental GetRentalByEquipmentId(int id);
        Rental GetRentalByRentalId(int id);
        void DeleteRental(int id);
              
    }
}
