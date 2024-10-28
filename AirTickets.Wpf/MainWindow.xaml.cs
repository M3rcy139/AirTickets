using System.Net.Http;
using AirTickets.Application.Dto.Response;
using System.Windows;
using Newtonsoft.Json;
using AirTickets.Core.Models;

namespace AirTickets.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HttpClient _httpClient;
        private Flight selectedFlight;
        private FlightResponse selectedFlightInfo;
        private List<FlightResponse> flightsInfo;

        public MainWindow()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            LoadFlights();
        }

        private async void LoadFlights()
        {
            try
            {
                var flights = await GetFlights();
                FlightsComboBox.ItemsSource = flights;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading flights: {ex.Message}");
            }
        }

        private async void FlightsComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (FlightsComboBox.SelectedValue != null)
            {
                selectedFlight = (Flight)FlightsComboBox.SelectedItem;
                await LoadFlightDetails(selectedFlight.Id);
                
                NameTextBlock.Text = "маршрут:";
                DepartureTimeTextBlock.Text = "Время отправления:";
                ArrivalTimeTextBlock.Text = "Время прибытия:";
                AircraftTextBlock.Text = "Модель самолета:";
                EconomyPriceTextBlock.Text = "Стоимость экономкласса";
                BusinessPriceTextBlock.Text = "Стоимость бизнескласса";

                NameTextBlock.Text += $" {selectedFlightInfo.RouteName}";
                DepartureTimeTextBlock.Text += $" {selectedFlightInfo.DepartureTime.ToString()}";
                ArrivalTimeTextBlock.Text += $" {selectedFlightInfo.ArrivalTime.ToString()}";
                AircraftTextBlock.Text += $" {selectedFlightInfo.AircraftModel}";
                EconomyPriceTextBlock.Text += $" {selectedFlightInfo.EconomyClasPrice.ToString()} рублей";
                BusinessPriceTextBlock.Text += $" {selectedFlightInfo.BuisnessClassPrice.ToString()} рублей";
            }
        }
        private async Task LoadFlightDetails(int flightId)
        {
            try
            {
                selectedFlightInfo = await GetFlightDetails(flightId);
                SelectSeatsButton.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading seances: {ex.Message}");
            }
        }

        private void SelectSeatsButton_Click(object sender, RoutedEventArgs e)
        {
            if (FlightsComboBox.SelectedValue != null)
            {
                int flightId = (int)FlightsComboBox.SelectedValue;
                int aircraftId = selectedFlight.AircraftId;
                int totalBusinessSeats = selectedFlightInfo.TotalBusinessSeats;
                int totalEconomySeats = selectedFlightInfo.TotalEconomySeats;
                string aircraftModel = selectedFlightInfo.AircraftModel;

                var seatSelectionWindow = new SeatSelectionWindow(flightId, aircraftId, totalBusinessSeats, totalEconomySeats, aircraftModel);
                seatSelectionWindow.Show();
                this.Close();
            }
            else MessageBox.Show("Выберите рейс!");
        }

        private async void Support_Click(object sender, RoutedEventArgs e)
        {
            var supportWindow = new SupportWindow();
            supportWindow.ShowDialog();
        }

        // Метод для получения списка залов
        private async Task<List<Flight>> GetFlights()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("https://localhost:7186/api/Flight/get-all-flights");
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Flight>>(content);
        }

        // Метод для получения списка сеансов по залу
        private async Task<FlightResponse> GetFlightDetails(int flightId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://localhost:7186/api/Flight/get-flight-details/{flightId}");
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<FlightResponse>(content);
        }
    }
}