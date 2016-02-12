using SkiRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiRental.ServiceLayer
{
    public interface IRentalService
    {
        CreateRentalResult CreateRental(Rental rental);
        List<Rental> GetAllRentals();
        Rental GetRentalByRentalId(int id);
        void DeleteRental(int id);      
    }

    public enum CreateRentalResult{

        Success,
        EquipmentIsAlreadyRented
       
    }
}
