namespace SkiRental.DataAccess.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SkiRental.DataAccess.SkiRentalContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SkiRental.DataAccess.SkiRentalContext context)
        {
            var equipmentStates = new List<Models.EquipmentState>();
            equipmentStates.Add( context.EquipmentStates.Add(new Models.EquipmentState { Description = "Okay" }));
            equipmentStates.Add(context.EquipmentStates.Add(new Models.EquipmentState { Description = "Damaged, needs repair" }));
            equipmentStates.Add(context.EquipmentStates.Add(new Models.EquipmentState { Description = "Damaged, needs replacement" }));
            equipmentStates.Add(context.EquipmentStates.Add(new Models.EquipmentState { Description = "Remove from stock" }));

            var equipmentTypes = new List<Models.EquipmentType>();
            equipmentTypes.Add(context.EquipmentTypes.Add(new Models.EquipmentType { TypeName = "Skis", PricePerHour = 50 }));
            equipmentTypes.Add(context.EquipmentTypes.Add(new Models.EquipmentType { TypeName = "Ski Boots", PricePerHour = 20 }));
            equipmentTypes.Add(context.EquipmentTypes.Add(new Models.EquipmentType { TypeName = "Snowboarding Boots", PricePerHour = 15 }));
            equipmentTypes.Add(context.EquipmentTypes.Add(new Models.EquipmentType { TypeName = "Goggles", PricePerHour = 10 }));
            equipmentTypes.Add(context.EquipmentTypes.Add(new Models.EquipmentType { TypeName = "Helmets", PricePerHour = 10 }));
            equipmentTypes.Add(context.EquipmentTypes.Add(new Models.EquipmentType { TypeName = "Snowboards", PricePerHour = 50 }));
            equipmentTypes.Add(context.EquipmentTypes.Add(new Models.EquipmentType { TypeName = "Ski Poles", PricePerHour = 10 }));

            context.Equipments.Add(new Models.Equipment { ProductName = "SkiMaster2000", EquipmentType = equipmentTypes[0], EquipmentState = equipmentStates[0], PurchaseDate = DateTime.Now, PurchasePrice = 2500 });
            context.Equipments.Add(new Models.Equipment { ProductName = "SkiMaster2000", EquipmentType = equipmentTypes[0], EquipmentState = equipmentStates[0], PurchaseDate = DateTime.Now, PurchasePrice = 2500 });
            context.Equipments.Add(new Models.Equipment { ProductName = "SkiMaster2000", EquipmentType = equipmentTypes[0], EquipmentState = equipmentStates[0], PurchaseDate = DateTime.Now, PurchasePrice = 2500 });
            context.Equipments.Add(new Models.Equipment { ProductName = "SkiMaster2000", EquipmentType = equipmentTypes[0], EquipmentState = equipmentStates[0], PurchaseDate = DateTime.Now, PurchasePrice = 800 });
            context.Equipments.Add(new Models.Equipment { ProductName = "Alpina S Combi", EquipmentType = equipmentTypes[1], EquipmentState = equipmentStates[0], PurchaseDate = DateTime.Now, PurchasePrice = 800 });
            context.Equipments.Add(new Models.Equipment { ProductName = "Alpina S Combi", EquipmentType = equipmentTypes[1], EquipmentState = equipmentStates[0], PurchaseDate = DateTime.Now, PurchasePrice = 800 });
            context.Equipments.Add(new Models.Equipment { ProductName = "Alpina S Combi", EquipmentType = equipmentTypes[1], EquipmentState = equipmentStates[0], PurchaseDate = DateTime.Now, PurchasePrice = 800 });
            context.Equipments.Add(new Models.Equipment { ProductName = "Alpina S Combi", EquipmentType = equipmentTypes[1], EquipmentState = equipmentStates[0], PurchaseDate = DateTime.Now, PurchasePrice = 800 });
            context.Equipments.Add(new Models.Equipment { ProductName = "Burton Mint", EquipmentType = equipmentTypes[2], EquipmentState = equipmentStates[0], PurchaseDate = DateTime.Now, PurchasePrice = 1300 });
            context.Equipments.Add(new Models.Equipment { ProductName = "Burton Mint", EquipmentType = equipmentTypes[2], EquipmentState = equipmentStates[0], PurchaseDate = DateTime.Now, PurchasePrice = 1300 });
            context.Equipments.Add(new Models.Equipment { ProductName = "Oakley Goggles", EquipmentType = equipmentTypes[3], EquipmentState = equipmentStates[1], PurchaseDate = DateTime.Now, PurchasePrice = 700 });
            context.Equipments.Add(new Models.Equipment { ProductName = "Oakley Goggles", EquipmentType = equipmentTypes[3], EquipmentState = equipmentStates[0], PurchaseDate = DateTime.Now, PurchasePrice = 700 });
            context.Equipments.Add(new Models.Equipment { ProductName = "Oakley Goggles", EquipmentType = equipmentTypes[3], EquipmentState = equipmentStates[0], PurchaseDate = DateTime.Now, PurchasePrice = 700 });
            context.Equipments.Add(new Models.Equipment { ProductName = "Oakley Goggles", EquipmentType = equipmentTypes[3], EquipmentState = equipmentStates[0], PurchaseDate = DateTime.Now, PurchasePrice = 700 });
            context.Equipments.Add(new Models.Equipment { ProductName = "Alpine Helmet Holt", EquipmentType = equipmentTypes[4], EquipmentState = equipmentStates[0], PurchaseDate = DateTime.Now, PurchasePrice = 500 });
            context.Equipments.Add(new Models.Equipment { ProductName = "Alpine Helmet Holt", EquipmentType = equipmentTypes[4], EquipmentState = equipmentStates[0], PurchaseDate = DateTime.Now, PurchasePrice = 500 });
            context.Equipments.Add(new Models.Equipment { ProductName = "Alpine Helmet Holt", EquipmentType = equipmentTypes[4], EquipmentState = equipmentStates[0], PurchaseDate = DateTime.Now, PurchasePrice = 500 });
            context.Equipments.Add(new Models.Equipment { ProductName = "Alpine Helmet Holt", EquipmentType = equipmentTypes[4], EquipmentState = equipmentStates[0], PurchaseDate = DateTime.Now, PurchasePrice = 500 });
            context.Equipments.Add(new Models.Equipment { ProductName = "Burton Process", EquipmentType = equipmentTypes[5], EquipmentState = equipmentStates[0], PurchaseDate = DateTime.Now, PurchasePrice = 3000 });
            context.Equipments.Add(new Models.Equipment { ProductName = "Burton Process", EquipmentType = equipmentTypes[5], EquipmentState = equipmentStates[0], PurchaseDate = DateTime.Now, PurchasePrice = 3000 });
            context.Equipments.Add(new Models.Equipment { ProductName = "Roller Ski Pole", EquipmentType = equipmentTypes[6], EquipmentState = equipmentStates[0], PurchaseDate = DateTime.Now, PurchasePrice = 500 });
            context.Equipments.Add(new Models.Equipment { ProductName = "Roller Ski Pole", EquipmentType = equipmentTypes[6], EquipmentState = equipmentStates[1], PurchaseDate = DateTime.Now, PurchasePrice = 500 });
            context.Equipments.Add(new Models.Equipment { ProductName = "Roller Ski Pole", EquipmentType = equipmentTypes[6], EquipmentState = equipmentStates[0], PurchaseDate = DateTime.Now, PurchasePrice = 500 });
            context.Equipments.Add(new Models.Equipment { ProductName = "Roller Ski Pole", EquipmentType = equipmentTypes[6], EquipmentState = equipmentStates[0], PurchaseDate = DateTime.Now, PurchasePrice = 500 });

            context.RentalPlans.Add(new Models.RentalPlan { Duration = 4, Discount = 0.0 });
            context.RentalPlans.Add(new Models.RentalPlan { Duration = 24, Discount = 0.0 });
            context.RentalPlans.Add(new Models.RentalPlan { Duration = 168, Discount = 0.2 });
        }
    }
}
