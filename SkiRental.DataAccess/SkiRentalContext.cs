using SkiRental.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiRental.DataAccess
{
    public class SkiRentalContext : DbContext
    {
     
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentState> EquipmentStates { get; set; }
        public DbSet<EquipmentType> EquipmentTypes { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<RentalPlan> RentalPlans { get; set; }

        public SkiRentalContext()
            :base("SkiRentalContext")
        {
            
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
        }


    }
}
