namespace SkiRental.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        EquipmentTypeId = c.Int(nullable: false),
                        EquipmentStateId = c.Int(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false),
                        PurchasePrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EquipmentStates", t => t.EquipmentStateId, cascadeDelete: true)
                .ForeignKey("dbo.EquipmentTypes", t => t.EquipmentTypeId, cascadeDelete: true)
                .Index(t => t.EquipmentTypeId)
                .Index(t => t.EquipmentStateId);
            
            CreateTable(
                "dbo.EquipmentStates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EquipmentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                        PricePerHour = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RentalPlans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Duration = c.Int(nullable: false),
                        Discount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EquipmentId = c.Int(nullable: false),
                        CustomerName = c.String(),
                        CustomerPhoneNumber = c.String(),
                        StartTime = c.DateTime(nullable: false),
                        RentalPlanId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Equipments", t => t.EquipmentId, cascadeDelete: true)
                .ForeignKey("dbo.RentalPlans", t => t.RentalPlanId, cascadeDelete: true)
                .Index(t => t.EquipmentId)
                .Index(t => t.RentalPlanId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "RentalPlanId", "dbo.RentalPlans");
            DropForeignKey("dbo.Rentals", "EquipmentId", "dbo.Equipments");
            DropForeignKey("dbo.Equipments", "EquipmentTypeId", "dbo.EquipmentTypes");
            DropForeignKey("dbo.Equipments", "EquipmentStateId", "dbo.EquipmentStates");
            DropIndex("dbo.Rentals", new[] { "RentalPlanId" });
            DropIndex("dbo.Rentals", new[] { "EquipmentId" });
            DropIndex("dbo.Equipments", new[] { "EquipmentStateId" });
            DropIndex("dbo.Equipments", new[] { "EquipmentTypeId" });
            DropTable("dbo.Rentals");
            DropTable("dbo.RentalPlans");
            DropTable("dbo.EquipmentTypes");
            DropTable("dbo.EquipmentStates");
            DropTable("dbo.Equipments");
        }
    }
}
