using SkiRental.Models;
using SkiRental.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiRental.ServiceLayer
{
    public class RentalService : IRentalService
    {
        private IUnitOfWork uow;
        public RentalService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public CreateRentalResult CreateRental(Rental rental)
        {           
            if(uow.RentalRepository.GetRentalByEquipmentId(rental.EquipmentId) == null)
            {
                uow.RentalRepository.CreateRental(rental);
                uow.Save();
                return CreateRentalResult.Success;
            }
            else
            {
                return CreateRentalResult.EquipmentIsAlreadyRented;
            }
           
        }

        public void DeleteRental(int id)
        {
            uow.RentalRepository.DeleteRental(id);
            uow.Save();
        }

        public List<Rental> GetAllRentals()
        {
            return uow.RentalRepository.GetAllRentals();
        }

        public Rental GetRentalByRentalId(int id)
        {
            var rental = uow.RentalRepository.GetRentalByRentalId(id);
            return rental;
        }
    }
}
