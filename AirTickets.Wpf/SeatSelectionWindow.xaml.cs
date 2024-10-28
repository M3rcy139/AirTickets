using AirTickets.Application.Dto.Response;
using AirTickets.Wpf;
using AirTickets.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace AirTickets.Wpf
{
    public partial class SeatSelectionWindow : Window
    {
        private HttpClient _httpClient;
        private int _flightId;
        private int _aircraftId;
        private int _totalBusinnesSeats;
        private int _totalEconomySeats;
        private string _aircraftModel;
        private Button _selectedSeatButton;

        public SeatSelectionWindow(int flightId, int aircraftId, int totalBusinnesSeats, int totalEconomySeats, string aircraftModel)
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            _flightId = flightId;
            _aircraftId = aircraftId;
            _totalBusinnesSeats = totalBusinnesSeats;
            _totalEconomySeats = totalEconomySeats;
            _aircraftModel = aircraftModel;

            LoadSeats(); // Загружаем места при открытии окна
        }

        // Метод для загрузки мест
        private async void LoadSeats()
        {
            try
            {
                var seats = await GetSeats(_aircraftId);
                AircraftModelTextBlock.Text = _aircraftModel;
                PopulateSeatsGrid(seats);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки мест: {ex.Message}");
            }
        }

        // Метод для заполнения сетки мест
        private async Task PopulateSeatsGrid(List<Seat> seats)
        {
            try
            {
                int rows = 4; // Общее количество строк
                int columnsEconomy = _totalEconomySeats / rows; // Количество колонок для эконом-класса
                int columnsBusiness = _totalBusinnesSeats / rows; // Количество колонок для бизнес-класса
                int columnsTotal = columnsEconomy + columnsBusiness + 1; // Учитываем 1 колонку для разделения

                SeatsGrid.RowDefinitions.Clear();
                SeatsGrid.ColumnDefinitions.Clear();
                SeatsGrid.Children.Clear();

                // Добавляем строки
                for (int i = 0; i < rows; i++)
                {
                    SeatsGrid.RowDefinitions.Add(new RowDefinition());
                }

                // Добавляем столбцы, включая пробел между секциями
                for (int i = 0; i < columnsTotal; i++)
                {
                    SeatsGrid.ColumnDefinitions.Add(new ColumnDefinition());
                }

                // Заполняем места эконом-класса
                for (int i = 0; i < _totalEconomySeats; i++)
                {
                    int seatId = seats[i].Id;

                    // Запрашиваем информацию для каждого места
                    SeatInfoResponse seatInfo = await GetSeatInfo(seatId, _flightId);

                    // Создаем кнопку места
                    var seatButton = new Button
                    {
                        Width = 30,
                        Height = 30,
                        Tag = seatInfo,
                        Margin = new Thickness(5),
                        Background = seatInfo.IsAvailable ? Brushes.White : Brushes.Gray,
                        BorderBrush = Brushes.Black,
                        BorderThickness = new Thickness(1),
                        Content = new Ellipse { Fill = seatInfo.IsAvailable ? Brushes.White : Brushes.Gray },
                    };

                    seatButton.Click += SeatButton_Click;

                    // Определяем строку и столбец для эконом-класса
                    int row = i / columnsEconomy;
                    int column = i % columnsEconomy;

                    // Устанавливаем позицию кнопки в сетке
                    Grid.SetRow(seatButton, row);
                    Grid.SetColumn(seatButton, column);

                    SeatsGrid.Children.Add(seatButton);
                }

                // Заполняем места бизнес-класса
                for (int j = 0; j < _totalBusinnesSeats; j++)
                {
                    int seatId = seats[_totalEconomySeats + j].Id;

                    // Запрашиваем информацию для каждого места
                    SeatInfoResponse seatInfo = await GetSeatInfo(seatId, _flightId);

                    // Создаем кнопку места
                    var seatButton = new Button
                    {
                        Width = 30,
                        Height = 30,
                        Tag = seatInfo,
                        Margin = new Thickness(5),
                        Background = seatInfo.IsAvailable ? Brushes.White : Brushes.Gray,
                        BorderBrush = Brushes.Black,
                        BorderThickness = new Thickness(1),
                        Content = new Ellipse { Fill = seatInfo.IsAvailable ? Brushes.White : Brushes.Gray },
                    };

                    seatButton.Click += SeatButton_Click;

                    // Определяем строку и столбец для бизнес-класса (с учетом пробела)
                    int row = j / columnsBusiness;
                    int column = columnsEconomy + 1 + (j % columnsBusiness); // Сдвигаем на 1 колонку вправо для пробела

                    // Устанавливаем позицию кнопки в сетке
                    Grid.SetRow(seatButton, row);
                    Grid.SetColumn(seatButton, column);

                    SeatsGrid.Children.Add(seatButton);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки мест: {ex.Message}");
            }
        }


        // Метод обработки клика по месту
        private async void SeatButton_Click(object sender, RoutedEventArgs e)
        {
            _selectedSeatButton = (Button)sender;
            var seat = (SeatInfoResponse)_selectedSeatButton.Tag;

            // Сбрасываем цвет границы у всех кнопок
            foreach (var child in SeatsGrid.Children)
            {
                if (child is Button button)
                {
                    button.BorderBrush = Brushes.Black;
                }
            }

            // Устанавливаем синий цвет границы для выбранной кнопки
            _selectedSeatButton.BorderBrush = Brushes.Blue;

            await LoadSeatInfo(seat.Id, _flightId);  // Загружаем информацию о месте
        }

        private void OpenPaymentWindowButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedSeatButton?.Tag is SeatInfoResponse seatInfo)
            {
                // Открываем окно оплаты и передаем информацию о выбранном месте и сеансе
                var paymentWindow = new PaymentWindow(seatInfo.Id, _flightId, seatInfo.Price);
                paymentWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите место для оплаты.");
            }
        }

        private async void Support_Click(object sender, RoutedEventArgs e)
        {
            var supportWindow = new SupportWindow();
            supportWindow.ShowDialog();
        }

        // Метод для получения информации о выбранном месте
        private async Task LoadSeatInfo(int seatId, int seanceId)
        {
            try
            {
                var seatInfo = await GetSeatInfo(seatId, seanceId);
                
                SeatInfoTextBlock.Text = $"Место: {seatInfo.SeatNumber}";
                PriceInfoTextBlock.Text = $"Стоимость: {seatInfo.Price} рублей";

                string Class = "";

                if (seatInfo.Class == "Economy") Class = "Экономкласс";
                else Class = "Бизнескласс";

                ClassInfoTextBlock.Text = $"Класс: {Class}";
                
                string IsAvailable = "";

                if (seatInfo.IsAvailable)
                {
                    IsAvailable = "Место доступно";
                }
                else
                {
                    IsAvailable = "Место недоступно";
                }
                AvailableInfoTextBlock.Text = $"Доступность места: {IsAvailable}";

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading seat info: {ex.Message}");
            }
        }

        // Метод для получения мест
        private async Task<List<Seat>> GetSeats(int aircraftId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://localhost:7186/api/seat/get-aircraft-seats/{aircraftId}");
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Seat>>(content);
        }

        // Метод для получения информации о конкретном месте
        private async Task<SeatInfoResponse> GetSeatInfo(int seatId, int flightId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://localhost:7186/api/seat/get-seat-info/{seatId}/{flightId}");
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<SeatInfoResponse>(content);
        }

        // Кнопка для возврата к выбору сеансов
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
