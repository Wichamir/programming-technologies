using Data.Implementation;

namespace Data;

public interface IDataApi
{
    public static IDataApi CreateDataRepository(string connectionString)
    {
        return new DataRepository(connectionString);
    }

    enum EventMode
    {
        Rent,
        Return
    }

    public void AddUser(int userId, string firstName, string lastName);
    public void RemoveUser(int userId);
    public IUser? GetUser(int userId);
    
    public void AddEvent(int eventId, int userId, int bookId, EventMode mode, DateTime occurrenceTime);
    public void RemoveEvent(int eventId);
    public IEvent? GetEvent(int eventId);

    public void AddBook(int bookId, string title, float fee = 0f);
    public void RemoveBook(int bookId);
    public IBook? GetBook(int bookId);

    public void UpdateState(int bookId, int quantity);
    public IState GetState(int bookId);
}
