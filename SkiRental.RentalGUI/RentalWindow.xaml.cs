using SkiRental.Models;
using SkiRental.RentalGUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Globalization;
using System.Text.RegularExpressions;
using System.ComponentModel;
using SkiRental.RentalGUI.Exceptions;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using SkiRental.RentalGUI.Services;

namespace SkiRental.RentalGUI
{
    

    /// <summary>
    /// Interaction logic for RentalWindow.xaml
    /// </summary>
    public partial class RentalWindow : Window
    {
        private IRentalService RentalService { get; set; }
        private RentalWindowVM ViewModel { get; set; }

        public RentalWindow(IRentalService rentalService, Equipment equipment)
        {
            RentalService = rentalService;

            InitializeComponent();

            ViewModel = DataContext as RentalWindowVM;
            ViewModel.Equipment = equipment;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            var plans = await RentalService.GetRentalPlansAsync();
            foreach (var plan in plans)
            {
                ViewModel.RentalPlanItems.Add(plan);
            }
        }
        
        private void Rent_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ViewModel != null && ViewModel.SelectedRentalPlan != null && ViewModel.CustomerName != "" && ViewModel.CustomerPhoneNumber != "";
        }

        private async void Rent_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                var rental = new Rental { EquipmentId = ViewModel.Equipment.Id, CustomerName = ViewModel.CustomerName, CustomerPhoneNumber = ViewModel.CustomerPhoneNumber, StartTime = DateTime.Now, RentalPlanId = ViewModel.SelectedRentalPlan.Id, Equipment = ViewModel.Equipment, RentalPlan = ViewModel.SelectedRentalPlan };
                await RentalService.CreateRentalAsync(rental);
                Close();
            }
            catch (HttpStatusException exception)
            {
                MessageBox.Show("Failed to rent item.", "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
            }
        }

        private void Cancel_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Cancel_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

        private async void cbRentalPlan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel.CalculatedPrice = await RentalService.GetRentalPriceAsync(ViewModel.SelectedRentalPlan, ViewModel.Equipment);
        }
    }

    public static class RentalWindowCommands
    {
        public static readonly RoutedUICommand Rent = new RoutedUICommand("Rent", "Rent", typeof(RentalWindowCommands));
        public static readonly RoutedUICommand Cancel = new RoutedUICommand("Cancel", "Cancel", typeof(RentalWindowCommands));
    }
}
