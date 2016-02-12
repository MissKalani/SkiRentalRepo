using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiRental.Models;
using SkiRental.RentalGUI.ViewModels;

namespace SkiRental.RentalGUI.Services
{
    public class RentalService : IRentalService
    {
        private IRestService restService;
        private List<RentalPlanItem> rentalPlans;
        private List<Equipment> availableEquipment;
        private List<RentalItem> rentals;

        public RentalService(IRestService restService)
        {
            this.restService = restService;
            rentalPlans = new List<RentalPlanItem>();
            availableEquipment = new List<Equipment>();
            rentals = new List<RentalItem>();
        }

        public async Task<List<Equipment>> GetAvailableEquipmentAsync()
        {
            if (availableEquipment.Count == 0)
            {
                availableEquipment = await RequestAvailableEquipmentAsync();
            }
            
            return availableEquipment;
        }

        public async Task<List<RentalItem>> GetRentalsAsync()
        {
            if (rentals.Count == 0)
            {
                rentals = await RequestRentalsAsync();
            }

            return rentals;
        }

        public async Task<List<RentalPlanItem>> GetRentalPlansAsync()
        {
            if (rentalPlans.Count == 0)
            {
                rentalPlans = await RequestRentalPlansAsync();
            }

            return rentalPlans;
        }

        public async Task<double> GetRentalPriceAsync(RentalPlan plan, Equipment equipment)
        {
            var price = await restService.GetAsync<double>("api/prices?planId=" + plan.Id + "&equipmentId=" + equipment.Id);
            return price;
        }

        public async Task<Rental> CreateRentalAsync(Rental rental)
        {
            // Store navigational properties.
            var equipment = rental.Equipment;
            var plan = rental.RentalPlan;

            // Update the server.
            rental = await restService.PostAsync("api/rentals", rental);
            rental.RentalPlan = plan;
            rental.Equipment = equipment;

            // Update the local cache (if the server was updated successfully).
            rentals.Add(new RentalItem { Rental = rental, DueTime = GetDueTime(rental) });
            availableEquipment.Remove(availableEquipment.Find(e => e.Id == rental.EquipmentId));
            
            return rental;
        }

        public async Task ReturnRentalAsync(Rental rental)
        {
            // Update the server.
            await restService.DeleteAsync("api/rentals/" + rental.Id);

            // Update the local cache (if the server was updated successfully).
            rentals.Remove(rentals.Where(t => t.Rental.Id == rental.Id).Single());
            availableEquipment.Add(rental.Equipment);
        }

        public async Task Update()
        {
            availableEquipment = await RequestAvailableEquipmentAsync();
            rentals = await RequestRentalsAsync();
            rentalPlans = await RequestRentalPlansAsync();
        }



        private async Task<List<Equipment>> RequestAvailableEquipmentAsync()
        {
            var equipments = await restService.GetAsync<List<Equipment>>("api/equipments?rented=false");
            foreach (var equipment in equipments)
            {
                equipment.EquipmentType = await restService.GetAsync<EquipmentType>("api/types?equipmentId=" + equipment.Id);
                equipment.EquipmentState = await restService.GetAsync<EquipmentState>("api/states?equipmentId=" + equipment.Id);
            }

            return equipments;
        }

        private async Task<List<RentalItem>> RequestRentalsAsync()
        {
            var result = new List<RentalItem>();

            var rentals = await restService.GetAsync<List<Rental>>("api/rentals");
            foreach (var rental in rentals)
            {
                rental.RentalPlan = await restService.GetAsync<RentalPlan>("api/plans/" + rental.RentalPlanId);
                rental.Equipment = await restService.GetAsync<Equipment>("api/equipments/" + rental.EquipmentId);
                rental.Equipment.EquipmentType = await restService.GetAsync<EquipmentType>("api/types?equipmentId=" + rental.Equipment.Id);
                rental.Equipment.EquipmentState = await restService.GetAsync<EquipmentState>("api/states?equipmentId=" + rental.Equipment.Id);

                result.Add(new RentalItem { Rental = rental, DueTime = GetDueTime(rental) });
            }

            return result;
        }

        private async Task<List<RentalPlanItem>> RequestRentalPlansAsync()
        {
            var result = new List<RentalPlanItem>();

            var plans = await restService.GetAsync<List<RentalPlan>>("api/plans");
            foreach (var plan in plans)
            {
                result.Add(new RentalPlanItem { Plan = plan });
            }

            return result;
        }

        private DateTime GetDueTime(Rental rental)
        {
            return rental.StartTime.AddHours(rental.RentalPlan.Duration);
        }
    }
}
