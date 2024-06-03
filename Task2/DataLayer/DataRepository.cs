namespace Data;

internal class DataRepository : IDataApi
{
    private readonly string connectionString = "";

    private readonly List<User> users = new();
    private readonly List<Event> events = new();
    private readonly List<Book> catalog = new();

    public DataRepository(string connectionString)
    {
        this.connectionString = connectionString;
        if (connectionString == "")
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
            IQueryable<User> users = from user in db.Users select user;

            foreach (var user in users)
            {
                this.users.Add(new User(user.UserId, user.FirstName, user.LastName));
            }
        }
    }

    public void LoadEvents()
    {
        using (DataClassesDataContext db = new(connectionString))
        {
            IQueryable<Event> events = from @event in db.Events select @event;

            foreach (var @event in events)
            {
                this.events.Add(new Event(@event.EventId, @event.UserId, @event.BookId, @event.OccuranceTime));
            }
        }
    }

    public void LoadCatalog()
    {
        using (DataClassesDataContext db = new(connectionString))
        {
            IQueryable<Book> books = from book in db.Books select book;

            foreach (var book in books)
            {
                catalog.Add(new Book(book.BookId, book.Title, book.State, book.Fee));
            }
        }
    }

    public void AddUser(int userId, string firstName, string lastName)
    {
        using (DataClassesDataContext db = new(connectionString))
        {
            var newUser = new User(userId, firstName, lastName);
            users.Add(newUser);
            db.Users.InsertOnSubmit(new User { UserId = userId, FirstName = firstName, LastName = lastName });
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

    public void AddEvent(int eventId, int userId, int bookId, DateTime occurrenceTime)
    {
        using (DataClassesDataContext db = new(connectionString))
        {
            Event @event;
            @event = new Event(eventId, userId, bookId, occurrenceTime);
            events.Add(@event);
            db.Events.InsertOnSubmit(new Event { EventId = eventId, UserId = userId, BookId = bookId, OccuranceTime = occurrenceTime });
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

    public void AddBook(int bookId, string title, int state, float fee = 0f)
    {
        using (DataClassesDataContext db = new(connectionString))
        {
            var newBook = new Book(bookId, title, state, fee);
            catalog.Add(newBook);
            db.Books.InsertOnSubmit(new Book { BookId = bookId, Title = title, Fee = fee });
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

    public string GetUserFirstName(int userId)
    {
        using (DataClassesDataContext db = new(connectionString))
        {
            var user = db.Users.Where(u => u.UserId == userId).FirstOrDefault();
            return user?.FirstName;
        }
    }

    public string GetUserLastName(int userId)
    {
        using (DataClassesDataContext db = new(connectionString))
        {
            var user = db.Users.Where(u => u.UserId == userId).FirstOrDefault();
            return user?.LastName;
        }
    }

    public int GetEventUserId(int eventId)
    {
        using (DataClassesDataContext db = new(connectionString))
        {
            var @event = db.Events.Where(e => e.EventId == eventId).FirstOrDefault();
            return @event?.UserId ?? 0;
        }
    }

    public int GetEventBookId(int eventId)
    {
        using (DataClassesDataContext db = new(connectionString))
        {
            var @event = db.Events.Where(e => e.EventId == eventId).FirstOrDefault();
            return @event?.BookId ?? 0;
        }
    }

    public DateTime GetOccuranceTime(int eventId)
    {
        using (DataClassesDataContext db = new(connectionString))
        {
            var @event = db.Events.Where(e => e.EventId == eventId).FirstOrDefault();
            return @event?.OccuranceTime ?? DateTime.MinValue;
        }
    }

    public string GetBookTitle(int bookId)
    {
        using (DataClassesDataContext db = new(connectionString))
        {
            var book = db.Books.Where(b => b.BookId == bookId).FirstOrDefault();
            return book?.Title;
        }
    }

    public float GetBookFee(int bookId)
    {
        using (DataClassesDataContext db = new(connectionString))
        {
            var book = db.Books.Where(b => b.BookId == bookId).FirstOrDefault();
            return book?.Fee ?? 0f;
        }
    }

    public int GetBookState(int bookId)
    {
        using (DataClassesDataContext db = new(connectionString))
        {
            var book = db.Books.Where(b => b.BookId == bookId).FirstOrDefault();
            return book?.State ?? 0;
        }
    }

    public void UpdateUser(int userId, string firstName, string lastName)
    {
        using (DataClassesDataContext db = new(connectionString))
        {
            var user = db.Users.Where(u => u.UserId == userId).FirstOrDefault();
            if (user != null)
            {
                user.FirstName = firstName;
                user.LastName = lastName;
                db.SubmitChanges();
            }
        }
    }

    public void UpdateEvent(int eventId, int userId, int bookId, DateTime occurrenceTime)
    {
        using (DataClassesDataContext db = new(connectionString))
        {
            var @event = db.Events.Where(e => e.EventId == eventId).FirstOrDefault();
            if (@event != null)
            {
                @event.UserId = userId;
                @event.BookId = bookId;
                @event.OccuranceTime = occurrenceTime;
                db.SubmitChanges();
            }
        }
    }

    public void UpdateBook(int bookId, string title, int state, float fee)
    {
        using (DataClassesDataContext db = new(connectionString))
        {
            var book = db.Books.Where(b => b.BookId == bookId).FirstOrDefault();
            if (book != null)
            {
                book.Title = title;
                book.State = state;
                book.Fee = fee;
                db.SubmitChanges();
            }
        }
    }
}
