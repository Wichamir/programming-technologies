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
    public string GetUserFirstName(int userId);
    public string GetUserLastName(int userId);
    public void UpdateUser(int userId, string firstName, string lastName);

    public void AddEvent(int eventId, int userId, int bookId, DateTime occurrenceTime);
    public void RemoveEvent(int eventId);
    public int GetEventUserId(int eventId);
    public int GetEventBookId(int eventId);
    public DateTime GetOccuranceTime(int eventId);
    public void UpdateEvent(int eventId, int userId, int bookId, DateTime occurrenceTime);

    public void AddBook(int bookId, string title, int state, float fee = 0f);
    public void RemoveBook(int bookId);
    public string GetBookTitle(int bookId);
    public float GetBookFee(int bookId);
    public int GetBookState(int bookId);
    public void UpdateBook(int bookId, string title, int state, float fee);
}
