using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Windows;

namespace AirTickets.Wpf
{
    /// <summary>
    /// Логика взаимодействия для SupportWindow.xaml
    /// </summary>
    public partial class SupportWindow : Window
    {
        public SupportWindow()
        {
            InitializeComponent();
        }

        private async void SupportButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var message = MessageTextBox.Text;

                if (string.IsNullOrWhiteSpace(message))
                {
                    MessageBox.Show("Сообщение не может быть пустым!");
                    return;
                }

                using (var client = new HttpClient())
                {
                    // Укажите правильный URL контроллера оплаты
                    var url = "https://localhost:7186/api/Support/report-issue";

                    var content = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(url, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        MessageBox.Show(result, "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Ошибка: {error}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при выполнении запроса: {ex.Message}");
            }
        }
    }
}
