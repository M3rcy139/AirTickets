namespace AirTickets.Core.Models
{
    public class Payment
    {
        public Guid Id { get; set; }               
        public Guid UserId { get; set; }
        public string PaymentMethod { get; set; }
        public int TicketId { get; set; }
        public decimal Amount { get; set; }         
        public decimal Change { get; set; }          
        public DateTime PaymentDate { get; set; }    

        public Ticket Ticket { get; set; } 
        public User User { get; set; }
    }

}
