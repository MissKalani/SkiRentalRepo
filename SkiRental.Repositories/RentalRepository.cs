using SkiRental.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiRental.Models;

namespace SkiRental.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        private SkiRentalContext context;

        public RentalRepository(SkiRentalContext context)
        {
            this.context = context;
        }

        public void CreateRental(Rental rental)
        {            
           context.Rentals.Add(rental);
        }

        public void DeleteRental(int id)
        {
            var rental = context.Rentals.Find(id);
            context.Rentals.Remove(rental);
        }

        public List<Rental> GetAllRentals()
        {
            return context.Rentals.ToList();
        }

        public Rental GetRentalByEquipmentId(int id)
        {
            return context.Rentals.Where(r => r.EquipmentId == id).FirstOrDefault();          

        }

        public Rental GetRentalByRentalId(int id)
        {
            return context.Rentals.Where(r => r.Id == id).FirstOrDefault();
        }
    }
}
