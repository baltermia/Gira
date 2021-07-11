namespace Gira
{
    public class TicketControlEventArgs
    {
        public readonly Ticket Ticket;
        public TicketControlEventArgs(Ticket ticket)
        {
            Ticket = ticket;
        }
    }
}