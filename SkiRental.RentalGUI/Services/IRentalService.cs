using SkiRental.Models;
using SkiRental.RentalGUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiRental.RentalGUI.Services
{
    public interface IRentalService
    {
        Task<List<Equipment>> GetAvailableEquipmentAsync();

        Task<List<RentalItem>> GetRentalsAsync();

        Task<List<RentalPlanItem>> GetRentalPlansAsync();

        Task<double> GetRentalPriceAsync(RentalPlan plan, Equipment equipment);

        Task<Rental> CreateRentalAsync(Rental rental);

        Task ReturnRentalAsync(Rental rental);

        Task Update();
    }
}
