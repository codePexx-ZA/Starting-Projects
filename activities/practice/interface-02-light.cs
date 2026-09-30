public class Ticket
{
    public int Id { get; set; }
    public string Subject { get; set; }
}

public interface ITicketStore
{
    void Add(Ticket ticket);
    Ticket FindById(int id);
}

public class TicketStore : ITicketStore
{
    private List<Ticket> _tickets = new();

    public void Add(Ticket ticket)
    {
        _tickets.Add(ticket);
    }

    public Ticket FindById(int id)
    {
        return _tickets.FirstOrDefault(t => t.Id == id);
    }
}

public class TicketService
{
    private ITicketStore _store;

    public TicketService(ITicketStore store)
    {
        _store = store;
    }

    public string Open(int id)
    {
        Ticket ticket = _store.FindById(id);
        if (ticket == null)
        {
            return "missing";
        }
        return "open " + ticket.Subject;
    }
}
