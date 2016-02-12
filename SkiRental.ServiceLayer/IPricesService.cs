using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiRental.ServiceLayer
{
    public interface IPricesService
    {
        double GetPrice(int equipmentId, int planId);
    }
}
