namespace MulakatLab.Domain;

public class Ticket
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Title { get; private set; }
    public TicketStatus Status { get; private set; } = TicketStatus.Open;
    public long TicketNumber { get; private set; }

    public Ticket(string title, long ticketNumber)
    {
        Title = title;
        TicketNumber = ticketNumber;
    }

    public void Close()
    {
        if (Status == TicketStatus.Closed)
            throw new InvalidOperationException("Ticket zaten kapalı");
            
        Status = TicketStatus.Closed;
    }
}

public enum TicketStatus { Open, Closed }