namespace ProjectManager.Core.ViewModels.Ticket.TicketChange
{
    public class TicketChangeViewModel
    {
        public string Property { get; set; }

        public string OldValue { get; set; }

        public string NewValue { get; set; }

        public DateTime ChangedOn { get; set; }
    }
}
