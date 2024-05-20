using Data;

namespace Data.Implementation;

internal class DataRepository : IDataApi
{
    private readonly string connectionString = "";
    
    private readonly List<IUser> users = new();
    private readonly List<IEvent> events = new();
    private readonly List<IBook> catalog = new();

    public DataRepository(string connectionString)
    {
        this.connectionString = connectionString;
        if(connectionString == "")
        {
            return;
        }
        LoadUsers();
        LoadEvents();
        LoadCatalog();
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
                this.catalog.Add(new Implementation.Book(book.BookId, book.Title, book.State, book.Fee));
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

    public void AddEvent(int eventId, int userId, int bookId, DateTime occurrenceTime)
    {
        using (DataClassesDataContext db = new(connectionString))
        {
            IEvent @event;
            @event = new RentBookEvent(eventId, userId, bookId, occurrenceTime);
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

    public void AddBook(int bookId, string title, int state, float fee = 0f)
    {
        using (DataClassesDataContext db = new(connectionString))
        {
            var newBook = new Book(bookId, title, state, fee);
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
}
