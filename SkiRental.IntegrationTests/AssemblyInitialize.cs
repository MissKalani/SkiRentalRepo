using Microsoft.VisualStudio.TestTools.UnitTesting;
using SkiRental.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiRental.IntegrationTests
{
    [TestClass]
    public class AssemblyInitialize
    {
        [AssemblyInitialize]
        public static void Initialize(TestContext testContext)
        {
            var context = new SkiRentalContext();
            context.Database.Delete();

            var config = new TestMigrationConfiguration();
            var migrator = new DbMigrator(config);
            migrator.Update();

        }
        [AssemblyCleanup]
        public static void CleanUp()
        {
            var context = new SkiRentalContext();
            context.Database.Delete();
        }
    }
}
