using AirTickets.Application.Dto.Request;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для PaymentWindow.xaml
    /// </summary>
    public partial class PaymentWindow : Window
    {
        private List<int> _seatIds;
        private int _flightId;
        private decimal _price;

        public PaymentWindow(List<int> seatIds, int flightId, decimal price)
        {
            InitializeComponent();
            _seatIds = seatIds;
            _flightId = flightId;
            _price = price;

            AmountTextBlock.Text = $"К оплате: {_price}₽";
        }

        private async void PayButton_Click(object sender, RoutedEventArgs e)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            string name = NameTextBox.Text;
            string surname = SurnameTextBox.Text;
            string email = EmailTextBox.Text;
            string paymentType = (PaymentTypeComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            if (!Regex.IsMatch(email, emailPattern))
            {
                MessageBox.Show("Пожалуйста, введите корректный email.");
                return;
            }

            if (!decimal.TryParse(AmountPaidTextBox.Text, out decimal amountPaid))
            {
                MessageBox.Show("Пожалуйста введите сумму");
                return;
            }

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(paymentType))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            if (paymentType == "Наличные")
            {
                MessageBox.Show("Оплата наличными производится на кассе");
                return;
            }

            if (amountPaid < _price)
            {
                MessageBox.Show("Недостаточно средств");
                return;
            }

            var paymentRequest = new PaymentRequest
            (
                Name: name,
                Surname: surname,
                Email: email,
                PaymentType: paymentType,
                AmountPaid: amountPaid,
                SeatIds: _seatIds,
                FlightId: _flightId
            );

            try
            {
                var CardWindow = new CardWindow(paymentRequest, _price);
                CardWindow.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при оплате: {ex.Message}");
            }
        }

        private async void Support_Click(object sender, RoutedEventArgs e)
        {
            var supportWindow = new SupportWindow();
            supportWindow.ShowDialog();
        }
    }
}

