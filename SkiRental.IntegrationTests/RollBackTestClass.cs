using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SkiRental.IntegrationTests
{
    [TestClass]
    public class RollBackTestClass
    {
        private TransactionScope tScope;

        [TestInitialize]
        public void Initialize()
        {
            tScope = new TransactionScope();
        }

        [TestCleanup]
        public void CleanUp()
        {
            tScope.Dispose();
        }

    }
}
