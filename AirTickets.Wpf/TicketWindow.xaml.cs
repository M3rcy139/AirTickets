using AirTickets.Application.Dto.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace AirTickets.Wpf
{
    /// <summary>
    /// Логика взаимодействия для TicketWindow.xaml
    /// </summary>
    public partial class TicketWindow : Window
    {
        private HttpClient _httpClient;
        private Guid _paymentId;

        public TicketWindow(Guid paymentId)
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            _paymentId = paymentId;

            LoadTicket();
        }

        private async void LoadTicket()
        {
            try
            {
                TicketsStackPanel.Children.Clear(); // Очищаем панель перед добавлением новых билетов

                var tickets = await GetTickets(_paymentId);

                EmailTextBlock.Text = tickets.Count > 1 ? "Билеты были отправлены вам на почту" : "Билет был отправлен вам на почту";

                foreach (var ticket in tickets)
                {
                    string seatClass = ticket.Class == "Economy" ? "Экономкласс" : "Бизнескласс";

                    var ticketInfo = new TextBlock
                    {
                        Text = $"Маршрут: {ticket.RouteName}\nМодель самолета: {ticket.AircraftModel}\n" +
                               $"Время отправления: {ticket.DepartureDateTime}\nВремя прибытия: {ticket.ArrivalDateTime}\n" +
                               $"Место: {ticket.SeatNumber}\nСтоимость: {ticket.Price} рублей\nКласс: {seatClass}\n" +
                               $"Владелец билета: {ticket.UserName} {ticket.UserSurname}\n\n",
                        FontSize = 14,
                        LineHeight = 20,
                        Margin = new Thickness(10, 0, 0, 5)
                    };
                    TicketsStackPanel.Children.Add(ticketInfo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки билетов: {ex.Message}");
            }
        }

        private async Task<List<TicketResponse>> GetTickets(Guid paymentId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://localhost:7186/api/Payment/get-tickets/ticket?paymentId={paymentId}");
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<TicketResponse>>(content);
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); 
        }
    }
}
