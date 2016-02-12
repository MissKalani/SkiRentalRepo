using SkiRental.DataAccess;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Reflection;

namespace SkiRental.IntegrationTests
{
    internal class TestMigrationConfiguration : DbMigrationsConfiguration<SkiRentalContext>
    {
        public TestMigrationConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsAssembly = Assembly.GetAssembly(typeof(SkiRentalContext));
            MigrationsNamespace = "SkiRental.DataModels.Migrations";
        }

        protected override void Seed(SkiRentalContext context)
        {
            var equipmentStates = new List<Models.EquipmentState>();
            equipmentStates.Add(context.EquipmentStates.Add(new Models.EquipmentState { Description = "Okay" }));
            equipmentStates.Add(context.EquipmentStates.Add(new Models.EquipmentState { Description = "Damaged, needs repair" }));
            equipmentStates.Add(context.EquipmentStates.Add(new Models.EquipmentState { Description = "Damaged, needs replacement" }));
            equipmentStates.Add(context.EquipmentStates.Add(new Models.EquipmentState { Description = "Remove from stock" }));

            var equipmentTypes = new List<Models.EquipmentType>();
            equipmentTypes.Add(context.EquipmentTypes.Add(new Models.EquipmentType { TypeName = "Skis", PricePerHour = 50 }));
            equipmentTypes.Add(context.EquipmentTypes.Add(new Models.EquipmentType { TypeName = "Ski Boots", PricePerHour = 15 }));
   
            base.Seed(context);
        }
    }
}