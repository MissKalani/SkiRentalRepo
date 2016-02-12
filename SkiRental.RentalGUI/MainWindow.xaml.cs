using Newtonsoft.Json;
using SkiRental.Models;
using SkiRental.RentalGUI.Exceptions;
using SkiRental.RentalGUI.Services;
using SkiRental.RentalGUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace SkiRental.RentalGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IRentalService RentalService { get; set; }
        private MainWindowVM ViewModel { get; set; }


        public MainWindow()
        {
            RentalService = new RentalService(new RestService("http://localhost:62899/"));

            InitializeComponent();

            ViewModel = DataContext as MainWindowVM;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            var availableEquipment = await RentalService.GetAvailableEquipmentAsync();
            foreach (var equipment in availableEquipment)
            {
                ViewModel.AvailableEquipment.Add(equipment);
            }
            
            var rentals = await RentalService.GetRentalsAsync();
            foreach (var rental in rentals)
            {
                ViewModel.Rentals.Add(rental);
            }
        }
        
        private void Exit_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Exit_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OpenRental_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = dgAvailableEquipment != null && dgAvailableEquipment.SelectedItem != null;
        }

        private async void OpenRental_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var equipment = dgAvailableEquipment.SelectedItem as Equipment;
            var window = new RentalWindow(RentalService, equipment);
            window.ShowDialog();

            // Update the view model.
            ViewModel.AvailableEquipment.Clear();
            ViewModel.Rentals.Clear();
            await LoadDataAsync();
        }

        private void Return_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ViewModel != null && ViewModel.SelectedRentalToReturn != null;
        }

        private async void Return_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                // Return the rental.
                await RentalService.ReturnRentalAsync(ViewModel.SelectedRentalToReturn);    
            }
            catch (HttpStatusException exception)
            {
                MessageBox.Show("Failed to return item.", "Error", MessageBoxButton.OK, MessageBoxImage.Stop);
            }

            // Update the view model.
            ViewModel.AvailableEquipment.Clear();
            ViewModel.Rentals.Clear();
            ViewModel.SelectedRentalToReturn = null;
            await LoadDataAsync();
        }

        private void About_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void About_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            AboutWindow window = new AboutWindow();
            window.ShowDialog();
        }

        private void Update_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private async void Update_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            await RentalService.Update();
            ViewModel.AvailableEquipment.Clear();
            ViewModel.Rentals.Clear();
            ViewModel.SelectedRentalToReturn = null;
            await LoadDataAsync();
        }
    }

    public static class MainWindowCommands
    {
        public static readonly RoutedUICommand Exit = new RoutedUICommand("Exit", "Exit", typeof(MainWindowCommands), new InputGestureCollection { new KeyGesture(Key.F4, ModifierKeys.Alt) });
        public static readonly RoutedUICommand Update = new RoutedUICommand("Update", "Update", typeof(MainWindowCommands));
        public static readonly RoutedUICommand OpenRental = new RoutedUICommand("OpenRental", "OpenRental", typeof(MainWindowCommands));
        public static readonly RoutedUICommand Return = new RoutedUICommand("Return", "Return", typeof(MainWindowCommands));
        public static readonly RoutedUICommand About = new RoutedUICommand("About", "About", typeof(MainWindowCommands));
    }
}