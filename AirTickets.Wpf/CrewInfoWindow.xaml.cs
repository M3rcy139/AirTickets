using AirTickets.Application.Dto.Response;
using AirTickets.Core.Models;
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
    /// Логика взаимодействия для CrewInfoWindow.xaml
    /// </summary>
    public partial class CrewInfoWindow : Window
    {
        private int _crewId;
        private HttpClient _httpClient;
        public CrewInfoWindow(int crewId)
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            _crewId = crewId;
            LoadTicket();
        }

        private async void LoadTicket()
        {
            try
            {
                CrewMembershipsStackPanel.Children.Clear(); // Очищаем панель перед добавлением новых билетов

                var crewMemberships = await GetCrewMemberships(_crewId);

                foreach (var crewMembership in crewMemberships)
                {
                    var memberInfo = new TextBlock
                    {
                        Text = $"Имя: {crewMembership.Name}\nПозиция: {crewMembership.Position}\n" +
                               $"Номер экипажа: {crewMembership.CrewId}\n\n",
                        FontSize = 14,
                        LineHeight = 20,
                        Margin = new Thickness(10, 0, 0, 0)
                    };
                    CrewMembershipsStackPanel.Children.Add(memberInfo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки экипажа: {ex.Message}");
            }
        }
        private async Task<List<CrewMember>> GetCrewMemberships(int crewId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://localhost:7186/api/Flight/get-crew-memberships/{crewId}");
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<CrewMember>>(content);
        }

        private async void Support_Click(object sender, RoutedEventArgs e)
        {
            var supportWindow = new SupportWindow();
            supportWindow.ShowDialog();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
