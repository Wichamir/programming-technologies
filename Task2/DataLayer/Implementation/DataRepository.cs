using Data;

namespace Data.Implementation;

internal class DataRepository : IDataApi
{
    private readonly string connectionString = "";
    
    private readonly List<IUser> users = new();
    private readonly List<IEvent> events = new();
    private readonly List<IBook> catalog = new();
    private readonly List<IState> states = new();

    public DataRepository(string connectionString)
    {
        this.connectionString = connectionString;
        LoadUsers();
        LoadEvents();
        LoadCatalog();
        LoadStates();
    }

    public void LoadUsers()
    {
        using (DataClassesDataContext db = new(connectionString))
        {
            IQueryable<Data.User> users = from user in db.Users select user;

            foreach (var user in users)
            {
                this.users.Add(new Implementation.Reader(user.UserId, user.FirstName, user.LastName));
            }
        }
    }

    public void LoadEvents()
    {
        using (DataClassesDataContext db = new(connectionString))
        {
            IQueryable<Data.Event> events = from @event in db.Events select @event;

            foreach (var @event in events)
            {
                this.events.Add(new Implementation.RentBookEvent(@event.EventId, @event.UserID, @event.BookId, @event.OccuranceTime));
            }
        }
    }

    public void LoadCatalog()
    {
        using (DataClassesDataContext db = new(connectionString))
        {
            IQueryable<Data.Book> books = from book in db.Books select book;

            foreach (var book in books)
            {
                this.catalog.Add(new Implementation.Book(book.BookId, book.Title, book.Fee));
            }
        }
    }

    public void LoadStates()
    {
        using (DataClassesDataContext db = new(connectionString))
        {
            IQueryable<Data.State> states = from state in db.States select state;

            foreach (var state in states)
            {
                this.states.Add(new Implementation.State(state.BookId, state.Quantity));
            }
        }
    }

    public void AddUser(int userId, string firstName, string lastName)
    {
        using (DataClassesDataContext db = new(connectionString))
        {
            var newUser = new Reader(userId, firstName, lastName);
            users.Add(newUser);
            db.Users.InsertOnSubmit(new Data.User { UserId = userId, FirstName = firstName, LastName = lastName });
            db.SubmitChanges();
        }
    }

    public void RemoveUser(int userId)
    {
        using (DataClassesDataContext db = new(connectionString))
        {
            users.RemoveAll(u => u.UserId == userId);
            var user = db.Users.FirstOrDefault(u => u.UserId == userId);
            if (user != null)
            {
                db.Users.DeleteOnSubmit(user);
                db.SubmitChanges();
            }
        }
    }

    public IUser? GetUser(int userId)
    {
        return users.Find(u => userId == u.UserId);
    }

    public void AddEvent(int eventId, int userId, int bookId, IDataApi.EventMode mode, DateTime occurrenceTime)
    {
        using (DataClassesDataContext db = new(connectionString))
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
            db.Events.InsertOnSubmit(new Data.Event { EventId = eventId, UserID = userId, BookId = bookId, OccuranceTime = occurrenceTime });
            db.SubmitChanges();
        }
    }

    public void RemoveEvent(int eventId)
    {
        using (DataClassesDataContext db = new(connectionString))
        {
            events.RemoveAll(e => e.EventId == eventId);
            var @event = db.Events.FirstOrDefault(e => e.EventId == eventId);
            if (@event != null)
            {
                db.Events.DeleteOnSubmit(@event);
                db.SubmitChanges();
            }
        }
    }

    public IEvent? GetEvent(int eventId)
    {
        return events.Find(e => eventId == e.EventId);
    }

    public void AddBook(int bookId, string title, float fee = 0f)
    {
        using (DataClassesDataContext db = new(connectionString))
        {
            var newBook = new Book(bookId, title, fee);
            catalog.Add(newBook);
            db.Books.InsertOnSubmit(new Data.Book { BookId = bookId, Title = title, Fee = fee });
            db.SubmitChanges();
        }
    }

    public void RemoveBook(int bookId)
    {
        using (DataClassesDataContext db = new(connectionString))
        {
            catalog.RemoveAll(b => b.BookId == bookId);
            var book = db.Books.FirstOrDefault(b => b.BookId == bookId);
            if (book != null)
            {
                db.Books.DeleteOnSubmit(book);
                db.SubmitChanges();
            }
        }
    }

    public IBook? GetBook(int bookId)
    {
        return catalog.Find(b => bookId == b.BookId);
    }

    public void UpdateState(int bookId, int quantity)
    {
        using (DataClassesDataContext db = new(connectionString))
        {
            var state = states.Find(s => s.BookId == bookId);

            if (state != null)
            {
                state.Quantity = quantity;
                var dbState = db.States.FirstOrDefault(s => s.BookId == bookId);
                if (dbState != null)
                {
                    dbState.Quantity = quantity;
                    db.SubmitChanges();
                }
            }
            else
            {
                states.Add(new State(bookId, quantity));
                db.States.InsertOnSubmit(new Data.State { BookId = bookId, Quantity = quantity });
                db.SubmitChanges();
            }
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

        using (DataClassesDataContext db = new(connectionString))
        {
            db.States.InsertOnSubmit(new Data.State { BookId = bookId, Quantity = 0 });
            db.SubmitChanges();
        }

        return state;
    }
}
