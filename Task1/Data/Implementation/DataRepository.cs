namespace Data.Implementation;

internal class DataRepository : IDataApi
{
    private List<IUser> users = new();
    private List<IEvent> events = new();
    private List<IBook> catalog = new();
    private List<IState> states = new();
    
    public DataRepository() {}
    
    public void AddUser(int userId, string firstName, string lastName)
    {
        var newUser = new Reader(userId, firstName, lastName);
        users.Add(newUser);
    }
    
    public void RemoveUser(int userId)
    {
        users.RemoveAll(u => u.UserId == userId);
    }

    public IUser? GetUser(int userId)
    {
        return users.Find(u => userId == u.UserId);
    }
    
    public void AddEvent(int eventId, int userId, int bookId, IDataApi.EventMode mode, DateTime occurrenceTime)
    {
        IEvent @event;
        
        switch (mode)
        {
            case IDataApi.EventMode.Rent:
                @event = new RentBookEvent(eventId, userId, bookId, occurrenceTime);
                break;
            case IDataApi.EventMode.Return:
                @event = new ReturnBookEvent(eventId, userId, bookId, occurrenceTime);
                break;
            default:
                throw new NotImplementedException();
        }
        
        events.Add(@event);
    }
    
    public void RemoveEvent(int eventId)
    {
        events.RemoveAll(e => e.EventId == eventId);
    }

    public IEvent? GetEvent(int eventId)
    {
        return events.Find(e => eventId == e.EventId);
    }
    
    public void AddBook(int bookId, string title, float fee = 0f)
    {
        var newBook = new Book(bookId, title, fee);
        catalog.Add(newBook);
    }

    public void RemoveBook(int bookId)
    {
        catalog.RemoveAll(b => b.BookId == bookId);
    }

    public IBook? GetBook(int bookId)
    {
        return catalog.Find(b => bookId == b.BookId);
    }
    
    public void UpdateState(int bookId, int quantity)
    {
        var state = states.Find(s => s.BookId == bookId);
        
        if (state != null)
        {
            state.Quantity = quantity;
        }
        else
        {
            states.Add(new State(bookId, quantity));
        }
    }

    public IState GetState(int bookId)
    {
        var state = states.Find(s => s.BookId == bookId);

        if (state != null)
        {
            return state;
        }
        
        state = new State(bookId, 0);
        states.Add(state);

        return state;
    }
}
